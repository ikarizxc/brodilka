namespace brodilka
{
    public class Champion : Monster, IAttack
    {
        public Champion() : base(120)
        {
            enemyAttack.Add("Charge", 35);
            enemyAttack.Add("Fatal Strike", 40);
            enemyAttack.Add("Impale", 50);
            enemyAttack.Add("Execute", 55);

            int namepicker = rand.Next(0, 3);
            if (namepicker == 0)
                name = "Rhozaq the Skullsplitter";
            if (namepicker == 1)
                name = "Omokk, The Gluttony";
            if (namepicker == 2)
                name = "Harromm the Earthshatterer";
        }
        public new void attack()
        {
            attackchoose = rand.Next(1, 101);
            if (attackchoose > 40)
            {
                damage = enemyAttack["Charge"];
                attackName = "Charge";
            }
            else if (attackchoose > 25)
            {
                damage = enemyAttack["Fatal Strike"];
                attackName = "Fatal Strike";
            }

            else if (attackchoose > 10)
            {
                damage = enemyAttack["Impale"];
                attackName = "Impale";
            }
            else
            {
                damage = enemyAttack["Execute"];
                attackName = "Execute";
            }
        }
    }
}
