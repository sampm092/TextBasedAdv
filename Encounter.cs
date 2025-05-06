namespace Out
{
    class Encounter
    {
        static Random rand = new Random();

        public static void FirstEncounter()
        {
            Console.WriteLine("Kamu membuka pintu yang ternyata tidak dikunci.");
            Console.WriteLine("Tanpa basa-basi, sesuatu datang ke arahmu dengan ujud memberikanmu celaka.");
            Console.WriteLine("Kamu tidak memiliki pilihan selain membela diri.");
            Console.ReadKey();
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0)
            {
                Console.WriteLine("==========================");
                Console.WriteLine("|     [A-ttack] [D-efend]  |");
                Console.WriteLine("|     [P-otion] [R-un]     |");
                Console.WriteLine("==========================");
                Console.WriteLine("You have " + Program.player.health + " health left.");
                Console.WriteLine("You have " + Program.player.potion + " potions left.");
                String tempCommand = Console.ReadLine();
                if (tempCommand.ToLower() == "a" || tempCommand.ToLower() == "attack")
                //Attack Command
                {
                    int pDamageValue = p - Program.player.defenseValue;
                    int pAttack = rand.Next(0, Program.player.weaponValue) + rand.Next(1, 1+Program.player.attackValue);
                    Console.WriteLine("Sebilah pedang di tangan, kamu mengayunkannya ke arah " + n + " dan dia menyerang balik");
                    Console.WriteLine("Kamu kehilangan " + pDamageValue + " poin darah dan memberikan luka kepadanya sebanyak " + pAttack + " poin darah");
                    Program.player.health =- pDamageValue;
                    h =- pAttack;
                }
                else if (tempCommand.ToLower() == "d" || tempCommand.ToLower() == "defend")
                //Defend Command
                {

                }
                else if (tempCommand.ToLower() == "p" || tempCommand.ToLower() == "potion")
                //Potion Command
                {

                }
                else if (tempCommand.ToLower() == "r" || tempCommand.ToLower() == "run")
                //Run Command
                {

                }
                Console.ReadKey();

            }
        }

    }
}