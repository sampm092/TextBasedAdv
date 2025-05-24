namespace MyApp
{
    public class Encounter
    {
        static Random rand = new Random();

        public static void FirstEncounter() //untuk ruangan 1
        {
            Function.Print("Kamu membuka pintu yang ternyata tidak dikunci.", 15);
            Function.Print("Tiba-tiba, suatu entitas maju ke arahmu tanpa basa-basi.", 15);
            Function.Print("Kamu tidak memiliki pilihan selain membela diri.", 15);
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Troll", 1, 4);
            Function.Print("Kamu melihat ke bawah dan menemukan sebuah kunci yang sepertinya jatuh", 15);
            Function.Print("dari badan monster tadi.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu mendapatkan 1 buah kunci!.", 15);
            Function.Print("Sepertinya kunci ini penting untuk keluar dari tempat ini.", 15);
            Program.player.key += 1;
            Program.player.position = 11;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah maju dan ternyata bertemu jalan bercabang.", 15);
        }

        public static void SecondEncounter() //untuk ruangan 3
        {
            Function.Print("Kamu melangkah maju menuju lorong dan tampaklah ruangan baru di depan.", 15);
            Function.Print("Cahaya redup beberapa lilin menerangi sebagian ruangan.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Dari tengah ruangan terlihat sosok makhluk yang sedang duduk dan bersiaga.", 15);
            Function.Print("Entah karena instingnya, tiba-tiba dia melihat ke arahmu dan bersiap untuk menyerang!", 15);
            Combat(false, "Ogre", 2, 5);
            Function.Print("Kamu melihat ke bawah dan menemukan sebuah kunci lagi.", 15);
            Function.Print("Kamu mendapatkan 1 buah kunci!.", 15);
            Program.player.key += 1;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah maju dan bertemu dengan jalan bercabang lagi.", 15);
        }

        public static void ThirdEncounter() //untuk ruangan 4
        {
            Function.Print("Kadksajdajdjsakdjan.", 15);
            Function.Print("Cahaya redup beberapa lilin menerangi sebagian ruangan.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Dari tengah ruangan terlihat sosok makhluk yang sedang duduk dan bersiaga.", 15);
            Function.Print("Entah karena instingnya, tiba-tiba dia melihat ke arahmu dan bersiap untuk menyerang!", 15);
            Combat(false, "Ogre", 2, 5);
            Function.Print("Kamu melihat ke bawah dan menemukan sebuah kunci lagi.", 15);
            Function.Print("Kamu mendapatkan 1 buah kunci!.", 15);
            Program.player.key += 1;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah maju dan bertemu dengan jalan bercabang lagi.", 15);
        }
        public static void ChestEncounter() //ruangan chest
        {
            Function.Print("Kamu sampai di ruangan kosong, tidak ada jalan lain setelah ruangan ini. ", 15);
            Function.Print("Kamu melihat sebuah peti di ujung ruangan, tetapi ada yang menjaga peti itu. ", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Makhluk itu melihatmu dan menyerang!", 15);
            Combat(false, "Cobra", 2, 7);
            Function.Print("Kamu berjalan ke arah peti itu dan membukanya.", 15);
            Function.Print("Tampaklah ratusan keping emas di dalamnya.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu segera memasukkan semuanya ke penyimpananmu.");
            Function.Print("Kamu mendapatkan 300 keping koin!");
            Program.player.money += 300;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah kembali ke ruangan sebelumnya.", 15);
        }

        public static void BasicEncounter()
        {

            Console.Clear();
            Function.Print("Kamu melangkah maju dan dari balik bayangan kegelapan muncul sosok yang menyerangmu!", 15);
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void ClearedEncounter()
        {
            Console.Clear();
            Function.Print("Kamu melangkah ke ruangan yang ternyata terlihat familiar.", 15);
            Function.Print("Ruangan ini adalah ruangan yang sudah kamu jelajahi.", 15);
            Function.Print("Meskipun begitu, di balik kegelapan ruangan, sosok makhluk menyerangmu!", 15);
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void RandomEncounter()
        {
            //for random encounter after first
            switch (rand.Next(0, 1)) //switching the type of random encounter
            {
                case 0:
                    BasicEncounter();
                    break;
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = Program.player.GetPower();
                h = Program.player.GetHealth();
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
                    Function.Print("Sebilah pedang di tangan, kamu mengayunkannya ke arah " + n + " dan dia menyerang balik", 5);
                    int pDamageValue = p - Program.player.defenseValue;
                    if (pDamageValue < 0)
                    {
                        pDamageValue = 0;
                    }
                    int pAttack = rand.Next(0, Program.player.weaponValue) + rand.Next(1, 1 + Program.player.attackValue);
                    Function.Print("Kamu kehilangan " + pDamageValue + " poin darah dan memberikan luka kepadanya sebanyak " + pAttack + " poin darah", 5);
                    Program.player.health -= pDamageValue;
                    h -= pAttack;
                }
                else if (tempCommand.ToLower() == "d" || tempCommand.ToLower() == "defend")
                //Defend Command
                {

                    Function.Print("Kamu melihat " + n + " bersiap menyerangmu, dengan segera kamu bersiaga dan memposisikan diri untuk bertahan.", 5);
                    int pDamageValue = (p / 3) - Program.player.defenseValue;
                    if (pDamageValue < 0)
                    {
                        pDamageValue = 0;
                    }
                    int pAttack = (rand.Next(0, Program.player.weaponValue) + rand.Next(1, 1 + Program.player.attackValue)) / 2; //maybe error
                    pAttack = (int)Math.Ceiling((double)pAttack); //maybe error
                    Function.Print("Kamu kehilangan " + pDamageValue + " poin darah dan memberikan luka kepadanya sebanyak " + pAttack + " poin darah", 5);
                    Program.player.health -= pDamageValue;
                    h -= pAttack;

                }
                else if (tempCommand.ToLower() == "p" || tempCommand.ToLower() == "potion")
                //Potion Command
                {

                    if (Program.player.potion == 0)
                    {
                        Function.Print("Kamu kehabisan potion untuk digunakan dan " + n + "berkesempatan untuk menyerangmu yang sedang kebingungan", 5);
                        int pDamageValue = p;

                        Program.player.health -= pDamageValue;
                        Function.Print("Kamu kehilangan " + pDamageValue + " poin darah", 5);
                    }
                    else
                    { //maybe error
                        Function.Print("Kamu mengambil sebuah potion dan segera menggunakannya", 5);
                        int heal = 10;
                        int missingHealth = Program.player.maxHealth - Program.player.health;

                        if (missingHealth == 0)
                        {
                            heal = 0;
                        }
                        else if (heal > missingHealth)
                        {
                            heal = missingHealth;
                        }
                        else if (heal <= missingHealth)
                        {
                            // Optional: clamp to a maximum heal value (e.g., 10)
                            heal = Math.Min(heal, 10);
                        }


                        Function.Print("Kamu mendapatkan " + heal + " poin darah", 20);
                        Program.player.health += heal;
                        Program.player.potion -= 1;
                        int pDamageValue = rand.Next(0, p + 1) - Program.player.defenseValue;
                        if (pDamageValue < 0)
                        {
                            pDamageValue = 0;
                        }
                        Function.Print(n + " menyerangmu setelah meminum potion dan memberikan " + pDamageValue + " poin serangan", 5);
                        Program.player.health -= pDamageValue;

                    }
                }
                else if (tempCommand.ToLower() == "r" || tempCommand.ToLower() == "run")
                //Run Command
                {
                    if (rand.Next(0, 2) == 0)
                    {

                        Function.Print("Kamu merasa pertarungan ini tidak dapat dimenangkan dan mencoba untuk mencari kesempatan untuk kabur dari " + n + ".", 5);
                        Function.Print("Kamu tidak menemukan celah dan " + n + " menyerangmu!", 5);
                        int pDamageValue = (int)Math.Ceiling((double)p * (3 / 2)); //maybe error

                        Program.player.health -= pDamageValue;
                        Function.Print("Kamu kehilangan " + pDamageValue + " poin darah", 20);
                    }
                    else
                    {

                        Function.Print("Kamu merasa pertarungan ini tidak dapat dimenangkan dan mencoba untuk mencari kesempatan untuk kabur dari " + n + ".", 5);
                        Function.Print("Kemampuanmu dalam menghindari serangannya sangat baik dan kamu berhasil kabur!", 5);
                        //ke town
                        Shop.LoadShop(Program.player);
                    }
                }
                Console.ReadKey();
                Console.Clear();

                if (Program.player.health <= 0)
                {
                    Function.Print(n + " menyerangmu dengan keras dan memberikan luka yang parah. Kamu tidak dapat berdiri lagi dan kehilangan kesadaran...", 5);
                    Console.WriteLine("~~ GAME OVER ~~");
                    Console.ReadKey();
                    Environment.Exit(0); //exit the program
                }
            }

            int goldValue = Program.player.GetMoney();
            int expValue = Program.player.GetXP();
            Function.Print("Kamu berhasil mengalahkan " + n + ". Kamu mendapatkan " + goldValue + " koin!", 5);
            Function.Print("Kamu mendapatkan " + expValue + " poin exp!", 5);
            Program.player.money += goldValue;
            Program.player.exp += expValue;
            if (Program.player.CanLevelUp())
            {
                Program.player.LevelUp();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static string GetName()
        {
            if (IsChristmas())
            {
                switch (rand.Next(0, 4))
                {
                    case 0:
                        return "Snow Golem";
                    case 1:
                        return "Pine Treant";
                    case 2:
                        return "Mad Deer";
                    case 3:
                        return "Crazy Santa";
                }
            }
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Slime";
                case 1:
                    return "Bat";
                case 2:
                    return "Big Bug";
                case 3:
                    return "Mini Golem";
            }
            return "Goblin"; //default
        }

        public static bool IsChristmas()  //adding event
        {
            DateTime time = DateTime.Now;
            if (time.Month == 12 && time.Day >= 15)
                return true;
            return false;
        }
    }
}