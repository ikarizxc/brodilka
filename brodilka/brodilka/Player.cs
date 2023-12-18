namespace brodilka
{
    public class Player: Tile
    {
        int health;
        int dice; // удача
        int gold;

        // изучены атаки или нет
        public bool attack2learned { get; set; } 
        public bool attack3learned { get; set; }
        public bool healLearned { get; set; }

        // урон оружия
        public int attack1 { get; set; }
        public int attack2 { get; set; }
        public int attack3 { get; set; }
        // лечение
        public int heal { get; set; }

        public Player(int c, int r) : base(c, r, "player")
        {
            health = 100;
            gold = 0;
            dice = 1;
            attack2learned = false;
            attack3learned = false;
            healLearned = false;
            attack1 = 20;
            attack2 = 35;
            attack3 = 50;
            heal = 10;
        }

        public int Dice
        {
            get { return dice; }
            set { dice = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        public void TakeDamage(int h)
        {
            health -= h;
        }
    }
}
