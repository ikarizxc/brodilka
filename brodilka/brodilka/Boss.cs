namespace brodilka
{
    public class Boss : Monster, IAttack
    {
        public Boss() : base(150)
        {
            enemyAttack.Add("Desecrate", 65);
            enemyAttack.Add("Obliterate", 65);
            enemyAttack.Add("Conflagrate", 75);
            enemyAttack.Add("Decapitate", 80);

            int namepicker = rand.Next(0, 3);
            if (namepicker == 0)
                name = "Alexei, Sword of the Nightfall";
            if (namepicker == 1)
                name = "The Dark Knight";
            if (namepicker == 2)
                name = "Lancaster, Bane of Aran";
        }
        public new void attack()
        {
            attackchoose = rand.Next(1, 101);
            if (attackchoose > 40)
            {
                damage = enemyAttack["Desecrate"];
                attackName = "Desecrate";
            }

            else if (attackchoose > 25)
            {
                damage = enemyAttack["Obliterate"];
                attackName = "Obliterate";
            }

            else if (attackchoose > 10)
            {
                damage = enemyAttack["Conflagrate"];
                attackName = "Conflagrate";
            }

            else
            {
                damage = enemyAttack["Decapitate"];
                attackName = "Decapitate";
            }
        }
    }
}
