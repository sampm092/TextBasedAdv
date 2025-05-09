namespace Out
{
    public class Shop
    {
        static int armorUp;
        static int weaponUp;
        static int diffUp;

        public static void LoadShop(Player p)
        {
            // armorUp = p.defenseValue;
            // weaponUp = p.weaponValue;
            // diffUp = p.mods;

            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionPrice;
            int weaponPrice;
            int armorPrice;
            int diffPrice;
            while (true)
            {
                potionPrice = 20 + 10 * p.mods;
                armorPrice = 50 * (p.defenseValue + 1);
                weaponPrice = 55 * (p.attackValue + 1);
                diffPrice = 300 + 100 * p.mods;


                Console.WriteLine("==== SELAMAT DATANG ! ====");
                Console.WriteLine("==========================\n");
                Console.WriteLine("==========================");
                Console.WriteLine("| Tingkatkan apa?        |");
                Console.WriteLine("| [W-eapon]    : " + weaponPrice);
                Console.WriteLine("| [A-rmor]     : " + armorPrice);
                Console.WriteLine("| [P-otion]    : " + potionPrice);
                Console.WriteLine("| [D-ifficulty : " + diffPrice);
                Console.WriteLine("==========================");
                Console.WriteLine("Koin Kamu : " + p.money);
                string input = (Console.ReadLine() ?? string.Empty).ToLower() ;
                if (input == "w" || input == "weapon")
                {

                }
                else if (input == "a" || input == "armor")
                {

                }
                else if (input == "p" || input == "potion")
                {

                }
                else if (input == "d" || input == "diff" || input == "difficulty")
                {

                }
            }

        }
    }
}
