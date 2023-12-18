using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace brodilka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int size = 10; // размер игрового поля
        Random rand = new Random();
        Tile[,] grid;
        public Player player;
        Tile finishLine;
        BattleWindow battle;
        public bool busy = false;

        public void clearBoard()
        {
            grid = new Tile[size, size];
            Tile.TileColors["player"] = (Color)ColorConverter.ConvertFromString("#00FF0D");  // поле игрока
            Tile.TileColors["wall"] = (Color)ColorConverter.ConvertFromString("#000000");  // стены
            Tile.TileColors["endZone"] = (Color)ColorConverter.ConvertFromString("#FFC800"); // финиш

            buildGameBoard(size, size);

            player = new Player(0, 0);
            myGrid.Children.Add(player);

            finishLine = new Tile(9, 9, "endZone");
            myGrid.Children.Add(finishLine);

            goldCount.Text = ("Золото: " + player.Gold);
            health.Text = ("Здоровье: " + player.Health);
            luck.Text = ("Удача: " + player.Dice);
            attack1.Text = ("Урон меча: " + player.attack1);
            attack2.Visibility = Visibility.Hidden;
            attack3.Visibility = Visibility.Hidden;
            heal.Visibility = Visibility.Hidden;
        }


        private void buildGameBoard(int width, int height) // построение игровой доски
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = Tile.SIZE;
                    r.Height = Tile.SIZE;
                    r.Fill = new SolidColorBrush(Colors.LightGray);
                    myGrid.Children.Add(r);

                    r.HorizontalAlignment = HorizontalAlignment.Left;
                    r.VerticalAlignment = VerticalAlignment.Top;

                    Thickness theMargin = new Thickness(
                        Tile.START + x * (Tile.SIZE + Tile.SPACING),
                        Tile.START + y * (Tile.SIZE + Tile.SPACING), 0, 0);
                    r.Margin = theMargin;
                }
            }
        }

        private void createWalls() // создание стен
        {
            for (int i = 0; i < 30; i++)
            {
                makeWall();
            }
        }

        private void makeWall() // создание стены
        {
            List<int[]> empties = BlankSpots();

            int index = rand.Next(1, empties.Count - 2);

            int[] coordinates = empties[index];

            Tile tilenew = new Tile(coordinates[0], coordinates[1], "wall");
            myGrid.Children.Add(tilenew);
            grid[coordinates[0], coordinates[1]] = tilenew;

        }
        private List<int[]> BlankSpots() // проверка пустых полей
        {
            List<int[]> empties = new List<int[]>();

            // проходимся по вертикалям
            for (int r = 0; r < size; r++)
            {
                // проходимся по горизонталям
                for (int c = 0; c < size; c++)
                {
                    // если пусто
                    if (grid[c, r] == null)
                    {
                        // записываем координы
                        int[] position = new int[2];
                        position[0] = c;
                        position[1] = r;

                        empties.Add(position);
                    }
                }
            }
            return empties;
        }
        private bool moveDown()
        {
            if (player.Row == (size - 1) || (grid[player.Column, player.Row + 1] != null)) // если персонаж в самом низу, то он не двигается
            {
                return false;
            }
            else
            {
                player.MoveTo(player.Column, player.Row + 1);
                return true;
            }
        }
        private bool moveUp()
        {

            if (player.Row == 0 || grid[player.Column, player.Row - 1] != null) // если персонаж в самом верху, то он не двигается
            {
                return false;
            }
            else
            {
                player.MoveTo(player.Column, player.Row - 1);
                return true;
            }
        }
        private bool moveLeft()
        {
            if (player.Column == 0 || grid[player.Column - 1, player.Row] != null) // если персонаж в крайнем левом поле, то он не двигается 
            {
                return false;
            }
            else
            {
                player.MoveTo(player.Column - 1, player.Row);
                return true;
            }

        }
        private bool moveRight()
        {
            if (player.Column == (size - 1) || grid[player.Column + 1, player.Row] != null) // если персонаж в крайнем правом поле, то он не двигается 
            {
                return false;
            }
            else
            {
                player.MoveTo(player.Column + 1, player.Row);
                return true;
            }

        }
        private void Window_KeyUp(object sender, KeyEventArgs e) // движение персонажа
        {
            bool moved = false;
            if (!busy) // если "свободен"
            {
                if (e.Key == Key.Up)
                {
                    moved = moveUp();
                }
                else if (e.Key == Key.Down)
                {
                    moved = moveDown();

                }
                else if (e.Key == Key.Left)
                {
                    moved = moveLeft();
                }
                else if (e.Key == Key.Right)
                {
                    moved = moveRight();
                }
                if (moved) // проверка, куда двинулся
                {
                    if (player.Column == finishLine.Column && player.Row == finishLine.Row) // финиш
                    {
                        Win();
                    }
                    else // не финиш
                    {
                        ambush();
                        Find();
                    }
                }
            }
        }
        private void ambush() // есть засада или нет??
        {
            int chanceofAttack = rand.Next(0, 100); // кидает кубик

            if (chanceofAttack > 70) // повезло!! бой начинается
            {
                busy = true;
                battle = new BattleWindow(this);
                battle.Show();
            }
            health.Text = ("Здоровье: " + player.Health);
        }
        private void Find() // сокровищаа
        {
            if (!busy) // если не в битве
            {
                int findtreasure = rand.Next(0, 101); // бросание кубика

                if (findtreasure > 95)
                {
                    if (player.Dice < 4)
                        player.Dice++;
                    MessageBox.Show("Боги услышали ваши молитвы!" + "\n" + "Ваша удача возросла!");
                    luck.Text = ("Удача: " + player.Dice);
                }
                else if (findtreasure > 80)
                {
                    player.Health += 10;
                    MessageBox.Show("Вас благословили!" + "\n" + "Ваше здоровье восстановилось.");
                    health.Text = ("Здоровье: " + player.Health);
                }
                else if (findtreasure > 60) // что то новое!!
                {
                    Learn();
                }

                else if (findtreasure > 50)
                {
                    int goldfound = rand.Next(100, 1000);
                    player.Gold += goldfound;
                    goldCount.Text = ("Золото: " + player.Gold);
                    MessageBox.Show("Вы нашли " + goldfound + " золота!");
                }
            }
        }
        public void Learn() // новые атаки
        {
            if (player.attack2learned == false) // если не изучена, то изучаем
            {
                player.attack2learned = true;
                MessageBox.Show("Вы идете и наступаете на странный предмет. Вы поднимаете его и понимаете, что это старая перчатка, способная бить током. Поскольку она все еще выглядит заряженной, вы надеваете ее на случай нападения врагов.");
                attack2.Text = ("Урон перчатки: " + player.attack2);
                attack2.Visibility = Visibility.Visible;
            }

            else if (player.attack3learned == false) // если не изучена, то изучаем
            {
                player.attack3learned = true;
                MessageBox.Show("Вы находите на полу старый фолиант с несколькими вырванными страницами. Открыв его, вы понимаете, что это заклинание для вызова большого огня. Возможно, если вы найдете остальные страницы, ваши магические способности возрастут.");
                attack3.Text = ("Урон огненного шара: " + player.attack3);
                attack3.Visibility = Visibility.Visible;
            }

            else if (player.healLearned == false) // если не изучена, то изучаем
            {
                player.healLearned = true;
                MessageBox.Show("Вы наткнулись на странную статую. Орки, должно быть, украли ее из аббатства. На статуе начертаны молитвы, которые когда-то читали клирики. Прислушаются ли боги к вашему призыву в трудные времена?");
                heal.Text = ("Лечение: " + player.heal);
                heal.Visibility = Visibility.Visible;
            }

            else // если все атаки изучены, то мы их улучшаем
            {
                int increasewhich = rand.Next(1, 5);

                if (increasewhich > 4)
                {
                    player.attack1 += 10;
                    MessageBox.Show("После сражений со многими врагами ваше мастерство владения мечом возросло!");
                    attack2.Text = ("Урон меча: " + player.attack1);
                }

                else if (increasewhich > 3)
                {
                    player.attack2 += 10;
                    MessageBox.Show("Вы нашли небольшой шар, увеличивающий заряд вашей перчатки.");
                    attack2.Text = ("Урон перчатки: " + player.attack2);
                }

                else if (increasewhich > 2)
                {
                    player.attack3 += 5;
                    MessageBox.Show("Вы нашли вырванную страницу с гравюрами, изображающими, похоже, большой пожар.");
                    attack3.Text = ("Урон огненного шара: " + player.attack3);
                }

                else
                {
                    player.heal += 5;
                    MessageBox.Show("Вы наткнулись на еще одну священную статую. Вы быстро заучиваете молитву в надежде, что боги прислушаются.");
                    heal.Text = ("Лечение: " + player.heal);
                }
            }
        }

        public void reset() // сброс
        {
            clearBoard();
            createWalls();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e) // кнопка сброса
        {
            reset();
        }

        private void Win() // победа вместо обеда
        {
            MessageBox.Show("You have reached the finish line! Total gold found was " + player.Gold + ". But our princess is in another castle!");
            reset();
        }

        private void cleartButton_Click(object sender, RoutedEventArgs e)
        {
            clearBoard();
        }

    }
}
