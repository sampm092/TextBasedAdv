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
            Console.Clear();
            Combat(false, "Goblin", 1, 4);
            Console.WriteLine("Kamu mengalahkan monsternya");
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
                Console.WriteLine("========= BATTLE =========");
                Console.WriteLine("==========================\n");
                Console.WriteLine("    ~~  " + n + "  ~~");
                Console.WriteLine(n + " HP :  " + h + " poin. \n");
                Console.WriteLine("==========================");
                Console.WriteLine("|     [A-ttack] [D-efend]  |");
                Console.WriteLine("|     [P-otion] [R-un]     |");
                Console.WriteLine("==========================");
                Console.WriteLine("HP mu     : " + Program.player.health + " poin darah.");
                Console.WriteLine("Potion mu : " + Program.player.potion + " buah");
                Console.WriteLine("Pilih aksi : ");
                String tempCommand = Console.ReadLine() ?? string.Empty;
                if (tempCommand.ToLower() == "a" || tempCommand.ToLower() == "attack")
                //Attack Command
                {
                    Console.WriteLine("Sebilah pedang di tangan, kamu mengayunkannya ke arah " + n + " dan dia menyerang balik");
                    int pDamageValue = p - Program.player.defenseValue;
                    if (pDamageValue < 0)
                    {
                        pDamageValue = 0;
                    }
                    int pAttack = rand.Next(0, Program.player.weaponValue) + rand.Next(1, 1 + Program.player.attackValue);
                    Console.WriteLine("Kamu kehilangan " + pDamageValue + " poin darah dan memberikan luka kepadanya sebanyak " + pAttack + " poin darah");
                    Program.player.health -= pDamageValue;
                    h -= pAttack;
                }
                else if (tempCommand.ToLower() == "d" || tempCommand.ToLower() == "defend")
                //Defend Command
                {

                    Console.WriteLine("Kamu melihat " + n + " bersiap menyerangmu, dengan segera kamu bersiaga dan memposisikan diri untuk bertahan.");
                    int pDamageValue = (p / 3) - Program.player.defenseValue;
                    if (pDamageValue < 0)
                    {
                        pDamageValue = 0;
                    }
                    int pAttack = (rand.Next(0, Program.player.weaponValue) + rand.Next(1, 1 + Program.player.attackValue)) / 2; //maybe error
                    pAttack = (int)Math.Ceiling((double)pAttack); //maybe error
                    Console.WriteLine("Kamu kehilangan " + pDamageValue + " poin darah dan memberikan luka kepadanya sebanyak " + pAttack + " poin darah");
                    Program.player.health -= pDamageValue;
                    h -= pAttack;

                }
                else if (tempCommand.ToLower() == "p" || tempCommand.ToLower() == "potion")
                //Potion Command
                {

                    if (Program.player.potion == 0)
                    {
                        Console.WriteLine("Kamu kehabisan potion untuk digunakan dan " + n + "berkesempatan untuk menyerangmu yang sedang kebingungan");
                        int pDamageValue = p;

                        Program.player.health -= pDamageValue;
                        Console.WriteLine("Kamu kehilangan " + pDamageValue + " poin darah");
                    }
                    else
                    { //maybe error
                        Console.WriteLine("Kamu mengambil sebuah potion dan segera menggunakannya");
                        int heal = 10;
                        if (Program.player.health == heal)
                        {
                            heal = 0;
                        }
                        else if (Program.player.health < heal)
                        {
                            heal -= Program.player.health;
                        }
                        else if (heal < Program.player.health)
                        {
                            if (Program.player.maxHealth - Program.player.health < heal)
                            {
                                heal = Program.player.maxHealth - Program.player.health;
                            }
                            else
                            {
                                heal = 10;
                            }
                        }

                        Console.WriteLine("Kamu mendapatkan " + heal + " poin darah");
                        Program.player.health += heal;
                        Program.player.potion -= 1;
                        int pDamageValue = rand.Next(0, p + 1) - Program.player.defenseValue;
                        if (pDamageValue < 0)
                        {
                            pDamageValue = 0;
                        }
                        Console.WriteLine(n + " menyerangmu setelah meminum potion dan memberikan " + pDamageValue + " poin serangan");
                        Program.player.health -= pDamageValue;

                    }
                }
                else if (tempCommand.ToLower() == "r" || tempCommand.ToLower() == "run")
                //Run Command
                {
                    if (rand.Next(0, 2) == 0)
                    {

                        Console.WriteLine("Kamu merasa pertarungan ini tidak dapat dimenangkan dan mencoba untuk mencari kesempatan untuk kabur dari " + n + ". Kamu tidak menemukan celah dan " + n + " menyerangmu!");
                        int pDamageValue = (int)Math.Ceiling((double)p * (3 / 2)); //maybe error

                        Program.player.health -= pDamageValue;
                        Console.WriteLine("Kamu kehilangan " + pDamageValue + " poin darah");
                    }
                    else
                    {

                        Console.WriteLine("Kamu merasa pertarungan ini tidak dapat dimenangkan dan mencoba untuk mencari kesempatan untuk kabur dari " + n + ". Kemampuanmu dalam menghindari serangannya sangat baik dan kamu berhasil kabur!");
                        //ke town
                    }
                }
                Console.ReadKey();
                Console.Clear();

            }
        }

    }
}