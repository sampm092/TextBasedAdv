namespace Kabur
{
    public class Shop
    {
        // static int armorUp;
        // static int weaponUp;
        // static int diffUp;

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
            decimal ProgressBarInt = (decimal)p.exp / (decimal)p.LevelUpValue();
            int weaponPrice;
            int maxHPrice;
            int armorPrice;
            int diffPrice;
            while (true)
            {
                potionPrice = 20 + 10 * p.mods;
                maxHPrice = 45 * (p.maxHealth - 9);
                armorPrice = 50 * (p.defenseValue + 1);
                weaponPrice = 55 * (p.weaponValue + 1);
                diffPrice = 300 + 100 * p.mods;

                Console.Clear();
                Console.WriteLine("============================");
                Console.WriteLine("===== SELAMAT DATANG ! =====");
                Console.WriteLine("============================");
                Console.WriteLine(" Status " + p.name);
                Console.WriteLine(" Class " + p.currentClass );
                Console.WriteLine("============================");
                Console.WriteLine(" Level           : " + p.level);
                Console.WriteLine(" Exp : " );
                Console.Write("[");
                Function.ProgressBar("=", ProgressBarInt, 25);
                Console.WriteLine("]");
                Console.WriteLine("                  " + + p.exp + "/" + p.LevelUpValue());
                Console.WriteLine("---------------------------");
                Console.WriteLine(" Max HP          : " + p.maxHealth);
                Console.WriteLine(" HP              : " + p.health);
                Console.WriteLine(" Kekuatan serang : " + (p.attackValue + p.weaponValue));
                Console.WriteLine(" Ketahanan       : " + p.defenseValue);
                Console.WriteLine(" Potion          : " + p.potion);
                Console.WriteLine(" Kunci           : " + p.key);
                Console.WriteLine(" Posisi          : " + p.position);
                Console.WriteLine(" Kesulitan       : " + p.mods);
                Console.WriteLine("============================");
                Console.WriteLine(" Tingkatkan apa?        ");
                Console.WriteLine(" [W-eapon]     : " + weaponPrice);
                Console.WriteLine(" [A-rmor]      : " + armorPrice);
                Console.WriteLine(" [P-otion]     : " + potionPrice);
                Console.WriteLine(" [M-ax Health] : " + maxHPrice);
                Console.WriteLine(" [D-ifficulty] : " + diffPrice);
                Console.WriteLine("Koin Kamu : " + p.money);
                Console.WriteLine("K-embali?");
                String input = Console.ReadLine() ?? string.Empty;
                if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponPrice, p);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorPrice, p);
                }
                else if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionPrice, p);
                }
                else if (input == "m" || input == "maxH")
                {
                    TryBuy("maxH", maxHPrice, p);
                }
                else if (input == "d" || input == "diff" || input == "difficulty")
                {
                    TryBuy("diff", diffPrice, p);
                }
                else if (input == "k" || input == "keluar" || input == "exit")
                {
                    break;
                }
            }

        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.money >= cost)
            {
                if (item == "weapon") p.weaponValue++;
                else if (item == "armor") p.defenseValue++;
                else if (item == "potion") p.potion++;
                else if (item == "diff") p.mods++;
                else if (item == "maxH") p.maxHealth++;

                p.money -= cost;

            }
            else
            {
                Function.Print("Kamu tidak memiliki cukup uang", 15);
                Console.ReadKey();
            }

        }
    }
}
