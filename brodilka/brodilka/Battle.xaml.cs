using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace brodilka
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        MainWindow myOwner;
        Random rand = new Random();
        Monster enemy;

        BitmapImage gob = new BitmapImage();
        BitmapImage troop = new BitmapImage();
        BitmapImage champ = new BitmapImage();
        BitmapImage boss = new BitmapImage();

        public void loadImages()
        {
            gob.BeginInit();
            gob.UriSource = new Uri("pics/goblin.png", UriKind.Relative);
            gob.EndInit();

            troop.BeginInit();
            troop.UriSource = new Uri("pics/orcsquad.png", UriKind.Relative);
            troop.EndInit();

            champ.BeginInit();
            champ.UriSource = new Uri("pics/orcchampion.png", UriKind.Relative);
            champ.EndInit();

            boss.BeginInit();
            boss.UriSource = new Uri("pics/bosspic.png", UriKind.Relative);
            boss.EndInit();
        }

        public BattleWindow(MainWindow owner)
        {
            InitializeComponent();
            loadImages();
            int generatemobType = rand.Next(0, 100); // случайный враг

            if (generatemobType > 94)
            {
                enemy = new Boss();
                enemypic.Source = boss;
            }
            else if (generatemobType > 85)
            {
                enemy = new Champion();
                enemypic.Source = champ;
            }
            else if (generatemobType > 65)
            {
                enemy = new Squad();
                enemypic.Source = troop;
            }
            else
            {
                enemy = new Minion();
                enemypic.Source = gob;
            }
            myOwner = owner;

            enemyName.Text = enemy.Name;
            heroHP.Text = "Здоровье: " + myOwner.player.Health;
            enemyHP.Text = "Здоровье: " + enemy.Life;


            if (myOwner.player.attack2learned == true) // атаки изучены - становятся доступными
            {
                attackButton2.Visibility = Visibility.Visible;
            }
            if (myOwner.player.attack3learned == true)
            {
                attackButton3.Visibility = Visibility.Visible;
            }
            if (myOwner.player.healLearned == true)
            {
                heal.Visibility = Visibility.Visible;
            }
        }

        private int Roll() // бросок кубика
        {
            return rand.Next(1, 7);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myOwner.busy = false;
        }

        private void attackButton1_Click(object sender, RoutedEventArgs e)
        {
            Battle(myOwner.player.attack1, "Вы меч");
        }

        private void attackButton2_Click(object sender, RoutedEventArgs e)
        {
            Battle(myOwner.player.attack2, "Ваша электрическая перчатка");
        }

        private void attackButton3_Click(object sender, RoutedEventArgs e)
        {
            Battle(myOwner.player.attack3, "Созданное вами великое пламя");
        }

        private void attackButton4_Click(object sender, RoutedEventArgs e)
        {
            Heal(myOwner.player.heal);
        }

        void EnemyHit(IAttack hit) => hit.attack();

        public void Battle(int d, string s)
        {
            int playerRoll = 0;

            for (int i = 0; i < myOwner.player.Dice; i++)
            {
                playerRoll += Roll();
            }

            int enemyRoll = Roll();

            if (playerRoll > enemyRoll)
            {
                enemy.takeDamage(d);
                enemyHP.Text = "Здоровье: " + enemy.Life;
                combatLog.Text = s + " наносит " + d + " урона.";

                if (enemy.Life <= 0)
                {
                    int loot = rand.Next(100, 500);
                    enemyHP.Text = "Мёртв";
                    myOwner.player.Gold += loot;
                    myOwner.goldCount.Text = ("Золото: " + myOwner.player.Gold);
                    MessageBox.Show("Вы убили противника и подобрали с него " + loot + " золота.");

                    Close();
                }
            }

            else if (enemyRoll > playerRoll)
            {
                EnemyHit(enemy);
                myOwner.player.TakeDamage(enemy.Damage);

                combatLog.Text = "Враг парировал вашу атаку, атакуя " + enemy.Attack + ", нанося " + enemy.Damage + " урона.";
                heroHP.Text = "Здоровье: " + myOwner.player.Health;

                if (myOwner.player.Health <= 0)
                {
                    Close();
                    MessageBox.Show("Вы умерли!");
                    myOwner.reset();
                }
            }
        }

        public void Heal(int h)
        {
            int playerRoll = 0;

            for (int i = 0; i < myOwner.player.Dice; i++)
            {
                playerRoll += Roll();
            }

            int enemyRoll = Roll();

            if (playerRoll > enemyRoll)
            {
                myOwner.player.Health += h;
                heroHP.Text = "Здоровье: " + myOwner.player.Health;
                combatLog.Text = "Вы восполнили " + h + " единиц здоровья.";
            }

            else if (enemyRoll > playerRoll)
            {
                EnemyHit(enemy);

                myOwner.player.TakeDamage(enemy.Damage);

                combatLog.Text = "Перед тем, как вы восстановили себе здоровье, враг атаковал вас " + enemy.Attack + ", нанося " + enemy.Damage + " урона.";
                heroHP.Text = "Здоровье: " + myOwner.player.Health;

                if (myOwner.player.Health <= 0)
                {
                    Close();
                    MessageBox.Show("Вы умерли!");
                    myOwner.reset();
                }
            }
        }
    }
}
