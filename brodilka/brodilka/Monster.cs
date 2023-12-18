using System;
using System.Collections.Generic;

namespace brodilka
{
    public class Monster : IAttack
    {
        protected int life;
        protected string name;
        protected int damage;
        protected Dictionary<string, int> enemyAttack = new Dictionary<string, int>();
        protected Random rand = new Random();
        protected int attackchoose;
        protected string attackName;


        public Monster(int life)
        {
            this.life = life;
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public string Attack
        {
            get { return attackName; }
        }
        public void takeDamage(int h)
        {
            life -= h;
        }
        public void attack() { }
        public string Name
        {
            get { return name; }
        }
    }
}
