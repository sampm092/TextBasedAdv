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
            Combat(false, "Troll", 1, 4, 0);
            Function.Print("Kamu melihat ke bawah dan menemukan sebuah kunci yang sepertinya jatuh", 15);
            Function.Print("dari badan monster tadi.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu mendapatkan 1 buah kunci!.", 15);
            Function.Print("Sepertinya kunci ini penting untuk keluar dari tempat ini.", 15);
            Program.player.key += 1;
            Program.player.position = 11;
            Program.player.VisitedRooms.Add(11);      // Mark as visited 
            // Program.player.VisitedRoom.Add(11);
            // Program.player.VisitedRoom.Add(0);
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
            Combat(false, "Ogre", 2, 5, 1);
            Function.Print("Kamu melihat ke bawah dan menemukan sebuah kunci lagi.", 15);
            Function.Print("Kamu mendapatkan 1 buah kunci!.", 15);
            Program.player.key += 1;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah maju dan bertemu dengan jalan bercabang lagi.", 15);
        }

        public static void ThirdEncounter() //untuk ruangan 4
        {
            Function.Print("Setelah melewati lorong tadi, tampaklah ruangan baru di depanmu.", 15);
            Function.Print("Sama seperti ruangan sebelumnya, tempat ini dipenuhi dengan cahaya redup lilin.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Bedanya, kamu tidak melihat siapapun menjaga ruangan ini.", 15);
            Function.Print("Kamu berjalan ke tengah ruangan dan tiba-tiba terdengar suara aneh!", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Crack! Dari bawah kakimu suara itu terdengar, spontan kamu melompat mundur", 15);
            Function.Print("Dari permukaan tanah muncul makhluk cukup besar berbentuk manusia tanah.", 15);
            Function.Print("Dan dia bersiap menyerangmu!", 15);
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Ember Golem", 1, 7, 2);
            Function.Print("Dari dalam tubuhnya keluar sebuah sebuah kunci lagi.", 15);
            Function.Print("Kamu mendapatkan 1 buah kunci!.", 15);
            Program.player.key += 1;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah maju dan bertemu dengan jalan bercabang lagi.", 15);
        }

        public static void FouthEncounter() //untuk ruangan 5
        {
            Function.Print("Kamu melangkah ke depan dan tampaklah ruangan baru lagi.", 15);
            Function.Print("Ruangan ini terang akibat banyaknya lilin.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Sama seperti ruangan-ruangan sebelumnya, di tengah ruangan bersiaga makhluk lainnya.", 15);
            Function.Print("Dia sudah mempersiapkan dirinya seperti memang mengharapkan kedatanganmu.", 15);
            Function.Print("Kamu juga mempersiapkan senjata dan maju untuk menyerang!", 15);
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Cyclops", 2, 10, 0);
            Function.Print("Kamu mendapatkan 1 buah kunci lagi!.", 15);
            Program.player.key += 1;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah maju dan kali ini bertemu dengan jalan bercabang tiga.", 15);
        }

        public static void FifthEncounter() //untuk ruangan 6
        {
            Function.Print("Kamu tiba di ruangan yang terlihat berbeda dengan ruangan lain.", 15);
            Function.Print("Di tengah ruangan terlihat seseorang yang duduk menunggu.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Di bawah kakinya terlihat enam kunci tergeletak.", 15);
            Function.Print("Dia menghampiri dirimu dan tampaklah wujudnya ternyata memang seorang manusia.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu mempersiapkan senjata tapi ternyata dia seperti tidak berniat menyerangmu!", 15);
            Function.Print("Alih-alih dia berkata:", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("'Di ruangan berikutnya, terdapat raksasa yang tidak dapat ku lawan.", 15);
            Function.Print(" Tadinya di ruangan ini dan di ruangan sebelah terdapat enam makhluk yang menjaga enam kunci'", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("'Aku sudah mengalahkan mereka dan bersiap untuk ke ruangan selanjutnya.", 15);
            Function.Print(" Tetapi ketika aku melihat makhluk yang ada di ruangan berikutnya.", 15);
            Function.Print(" Semangat juangku bagaikan terserap habis. Oleh sebab itu aku menunggu di sini.'", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("'Menantikan orang yang lebih layak untuk maju ke sana untuk menghabisi monster itu.", 15);
            Function.Print(" Aku akan menguji siapapun yang ingin maju ke sana dan juga akan memberikan keenam kunci ini.'", 15);
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                Function.Print("'Tidak ada jalan kembali setelah ini.", 15);
                Function.Print(" Apa kau memiliki nyali untuk menantangku?' [Y/T]", 15);
                string input3 = Console.ReadLine()!.ToLower();
                if (input3 == "y")
                {
                    Function.Print("'Bersiaplah!'", 15);
                    Console.ReadKey();
                    Console.Clear();
                    Combat(false, "Fallen Knight", 3, 15, 2);
                    Function.Print("'Kau sudah layak untuk lanjut. Ambillah kunci-kunci ini.", 15);
                    Program.player.key += 6;
                    Function.Print(" Kau membutuhkan sepuluh untuk membuka pintu ruangan terakhir.'", 15);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (input3 == "t")
                {
                    Function.Print("'Kembalilah ketika kau sudah siap!'", 15);
                    Program.player.position = 53;
                    break;
                }
                else
                {
                    Function.Print("Masukkan input sesuai pilihan!");
                    Console.Clear();
                }
            }
        }

        public static void FifthEncounterTwo() //untuk ruangan 6 setelah ditanya
        {
            Function.Print("'Kau kembali.", 15);
            while (true)
            {
                Function.Print("'Tidak ada jalan kembali setelah ini.", 15);
                Function.Print(" Apa kau memiliki nyali untuk menantangku?' [Y/T]", 15);
                string input3 = Console.ReadLine()!.ToLower();
                if (input3 == "y")
                {
                    Function.Print("'Bersiaplah!'", 15);
                    Console.ReadKey();
                    Console.Clear();
                    Combat(false, "Fallen Knight", 3, 15, 2);
                    Function.Print("'Kau sudah layak untuk lanjut. Ambillah kunci-kunci ini.", 15);
                    Program.player.key += 6;
                    Function.Print(" Kau membutuhkan sepuluh untuk membuka pintu ruangan terakhir.'", 15);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (input3 == "t")
                {
                    Function.Print("'Kembalilah ketika kau sudah siap!'", 15);
                    Program.player.position = 53;
                    break;
                }
                else
                {
                    Function.Print("Masukkan input sesuai pilihan!");
                    Console.Clear();
                }
            }
        }

        public static void BossEncounter() //ruangan boss
        {

        }

        public static void ChestEncounter() //ruangan chest
        {
            Function.Print("Kamu sampai di ruangan kosong, tidak ada jalan lain setelah ruangan ini. ", 15);
            Function.Print("Kamu melihat sebuah peti di ujung ruangan, tetapi ada yang menjaga peti itu. ", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Makhluk itu melihatmu dan menyerang!", 15);
            Combat(false, "Cobra", 2, 7, 1);
            Function.Print("Kamu berjalan ke arah peti itu dan membukanya.", 15);
            Function.Print("Tampaklah ratusan keping emas di dalamnya.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu segera memasukkan semuanya ke penyimpananmu.", 15);
            Function.Print("Kamu mendapatkan 300 keping koin!", 15);
            Program.player.money += 300;
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu melangkah kembali ke ruangan sebelumnya.", 15);
        }

        public static void ChestEncounter2() //ruangan chest
        {
            Function.Print("Kamu sampai di ruangan kosong, tidak ada jalan lain setelah ruangan ini. ", 15);
            Function.Print("Kamu melihat sebuah peti di ujung ruangan, tetapi ada yang menjaga peti itu. ", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Makhluk itu melihatmu dan menyerang!", 15);
            Combat(false, "Shadow Fighter", 3, 4, 2);
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

        public static void RoomZero()
        {
            Console.Clear();
            Function.Print("Kamu melangkah ke ruangan yang ternyata terlihat familiar.", 15);
            Function.Print("Ruangan ini adalah ruangan pertama dimana kamu pertama sekali bangun.", 15);
            Console.ReadKey();
            Console.Clear();
        }

        public static void BasicEncounter()
        {

            Console.Clear();
            Function.Print("Kamu melangkah maju dan dari balik bayangan kegelapan muncul sosok yang menyerangmu!", 15);
            Console.ReadKey();
            Combat(true, "", 0, 0, 0);
        }

        public static void ClearedEncounter()
        {
            Console.Clear();
            Function.Print("Kamu melangkah ke ruangan yang ternyata terlihat familiar.", 15);
            Function.Print("Ruangan ini adalah ruangan yang sudah kamu jelajahi.", 15);
            Function.Print("Meskipun begitu, di balik kegelapan ruangan, sosok makhluk menyerangmu!", 15);
            Console.ReadKey();
            Combat(true, "", 0, 0, 0);
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

        public static void Combat(bool random, string name, int power, int health, int defense)
        {
            string n = "";
            int p = 0;
            int h = 0;
            int d = 0;

            if (random)
            {
                n = GetName();
                p = Function.GetPower();
                h = Function.GetHealth();
                d = Function.GetDefense();
            }
            else
            {
                n = name;
                p = power;
                h = health;
                d = defense;
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
                    int attackrangeup = Program.player.weaponValue + Program.player.attackValue;
                    int attackrangbot = attackrangeup - 2; //could be wrong
                    if (attackrangbot <= 0) attackrangbot = 0;
                    int pAttack = rand.Next(attackrangbot, attackrangeup) - d;
                    if (pAttack < 0)
                    {
                        pAttack = 0;
                    }
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
                //Run Command, make this run to previous map, not to shop
                {
                    if (rand.Next(0, 2) == 1)
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

            int goldValue = Function.GetMoney();
            int expValue = Function.GetXP();
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
            // if (IsChristmas())
            // {
            //     switch (rand.Next(0, 4))
            //     {
            //         case 0:
            //             return "Snow Golem";
            //         case 1:
            //             return "Pine Treant";
            //         case 2:
            //             return "Mad Deer";
            //         case 3:
            //             return "Crazy Santa";
            //     }
            // }
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

        // public static bool IsChristmas()  //adding event
        // {
        // DateTime time = DateTime.Now;
        // if (time.Month == 12 && time.Day >= 15)
        //     return true;
        // return false;
        // }
    }
}