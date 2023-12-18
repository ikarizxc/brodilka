namespace brodilka
{
    public class Squad : Monster, IAttack
    {
        public Squad() : base(90)
        {
            enemyAttack.Add("Piercing Shot", 20);
            enemyAttack.Add("Scorch", 30);
            enemyAttack.Add("Flank", 40);

            name = "Orc Raiders";
        }
        public new void attack()
        {
            attackchoose = rand.Next(1, 101);
            if (attackchoose > 40)
            {
                damage = enemyAttack["Piercing Shot"];
                attackName = "Piercing Shot";
            }
            else if (attackchoose > 10)
            {
                damage = enemyAttack["Scorch"];
                attackName = "Scorch";
            }
            else
            {
                damage = enemyAttack["Flank"];
                attackName = "Flank";
            }
        }
    }
}
