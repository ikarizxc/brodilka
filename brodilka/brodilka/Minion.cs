namespace brodilka
{
    public class Minion : Monster, IAttack
    {
        public Minion() : base(30)
        {
            enemyAttack.Add("Headbutt", 5);
            enemyAttack.Add("Kick", 10);
            enemyAttack.Add("Quick Strike", 15);
            enemyAttack.Add("Slash", 25);

            name = "Goblin Patroller";
        }
        public new void attack()
        {
            attackchoose = rand.Next(1, 101);
            if (attackchoose > 40)
            {
                damage = enemyAttack["Headbutt"];
                attackName = "Headbutt";
            }

            else if (attackchoose > 25)
            {
                damage = enemyAttack["Kick"];
                attackName = "Kick";

            }

            else if (attackchoose > 10)
            {
                damage = enemyAttack["Quick Strike"];
                attackName = "Quick Strike";
            }

            else
            {
                damage = enemyAttack["Slash"];
                attackName = "Slash";
            }
        }
    }
}
