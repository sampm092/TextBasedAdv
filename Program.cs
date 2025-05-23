using System.Text.Json;
namespace MyApp
{
    public class Program
    {
        public static Player player = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }


            player = Load(out bool newP);
            if (newP == true) Encounter.FirstEncounter();

            while (true)
            {
                switch (player.position)
                {
                    case 1:
                        Function.Print("Pilih jalan yang ingin kamu lewati: ", 15);
                        Console.WriteLine("Maju | Kanan | Shop");
                        string input1 = Console.ReadLine()!.ToLower();

                        switch (input1)
                        {
                            case "maju":
                                Encounter.SecondEncounter();
                                player.position = 21;
                                break;

                            case "kanan":
                                Function.Print("Ruangan ini sepertinya hanya ruangan biasa.", 15);
                                Console.ReadKey();
                                Encounter.RandomEncounter();
                                player.position = 22;
                                break;

                            case "shop":
                                Shop.LoadShop(player);
                                Console.Clear();
                                break;

                            default:
                                Function.Print("Masukkan input sesuai pilihan!");
                                break;
                        }
                        break;

                    case 22:
                        while (true)
                        {
                            Function.Print("Pilih jalan yang ingin kamu lewati: ", 15);
                            Console.WriteLine("Maju | Kiri | Shop");
                            string input2 = Console.ReadLine()!.ToLower();

                            switch (input2)
                            {
                                case "shop":
                                    Shop.LoadShop(player);
                                    Console.Clear();
                                    break;

                                case "maju":
                                    player.position = 23;
                                    Encounter.ChestEncounter();
                                    break;

                                case "kiri":
                                    Encounter.SecondEncounter();
                                    // player.position = 21;
                                    break;


                                default:
                                    Function.Print("Masukkan input sesuai pilihan!");
                                    break;
                            }
                            break;
                        }
                        break;
                    case 23:
                        while (true)
                        {
                            Console.WriteLine("Maju | Kanan | Shop");
                            string input = Console.ReadLine()!.ToLower();

                            switch (input)
                            {
                                case "maju":

                                    break;
                                case "kanan":
                                    Encounter.SecondEncounter();
                                    // player.position = 21;
                                    break;

                                case "shop":
                                    Shop.LoadShop(player);
                                    Console.Clear();
                                    break;
                                default:
                                    Function.Print("Masukkan input sesuai pilihan!");
                                    break;

                            }
                            break;
                        }
                        break;
                        // Add other cases as needed
                }

            }

            // while (mainLoop)
            // {

            // }

        }

        static Player NewStart(int i)
        {
            Player p = new Player();
            Console.Clear();
            Function.Print("Kabur!`", 50);

            while (true)
            {
                Function.Print("Namamu?", 50);
                string? input = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(input)) //avoid null input
                {
                    p.name = input;
                    p.id = i;
                    break;
                }
                Console.WriteLine("Nama diperlukan!");
            }

            bool Flag = false; //for the class loop
            while (Flag == false)
            {
                Flag = true;
                Console.WriteLine("Pilih kelas yang kamu inginkan : ");
                Console.WriteLine("Warrior, Knight, Alchemist");

                string? input = Console.ReadLine()!.ToLower();

                if (!string.IsNullOrWhiteSpace(input)) //avoid null input
                {
                    if (input == "warrior")
                    {
                        p.currentClass = Player.PLayerClass.Warrior;
                        p.attackValue += 2;
                    }
                    else if (input == "knight")
                    {
                        p.currentClass = Player.PLayerClass.Knight;
                        p.defenseValue += 2;
                    }
                    else if (input == "alchemist")
                    {
                        p.currentClass = Player.PLayerClass.Alchemist;
                        p.maxHealth += 4;
                        p.potion += 2;
                    }
                    else
                    {
                        Function.Print("Pilih kelas yang tersedia!");
                        Flag = false;
                    }

                }
                Console.WriteLine("Tolong masukkan kelas!");
            }

            Console.Clear();
            Function.Print("Kamu, " + p.name + ", menemukan diri terbangun di sebuah ruangan yang tak dikenal.", 15);
            Function.Print("Kamu melihat sekitar yang ternyata dikelilingi oleh tembok batu yang terlihat kokoh ", 15);
            Function.Print("dan sebuah pintu tampak diantaranya.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu tidak mengerti apa yang terjadi hingga bisa berada di sini. Tetapi kamu tahu satu hal", 15);
            Function.Print("Tempat ini berbahaya dan kamu harus kabur dari tempat ini!", 15);
            Console.ReadKey();
            Console.Clear();
            return p;

        }

        public static void Quit()
        {
            Save();
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void Save()
        {
            string path = "saves/" + player.id.ToString() + ".json"; //binary formatter can't be used -> use json

            var options = new JsonSerializerOptions
            {
                WriteIndented = true // makes the JSON pretty and readable
            };

            string json = JsonSerializer.Serialize(player, options);
            File.WriteAllText(path, json);
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            Console.WriteLine("Karakter: ");
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            // BinaryFormatter binFormatter = new BinaryFormatter();
            foreach (string p in paths)
            {
                try
                {
                    //find player saves
                    string json = File.ReadAllText(p);
                    Player player = JsonSerializer.Deserialize<Player>(json)!;
                    if (player != null)
                    {
                        players.Add(player);
                    }
                }
                catch
                {
                    Console.WriteLine("Player tidak ditemukan");
                }
            }

            idCount = players.Count;
            while (true)
            {

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + " : " + p.name);
                }


                Console.WriteLine("Pilih: (ketik 'create' untuk membuat karakter baru)");
                string[] data = (Console.ReadLine() ?? string.Empty).Split(":");

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    if (player.key == 0)
                                    {
                                        newP = true;
                                        return player;
                                    }
                                    else
                                    {
                                        return player;
                                    }
                                }
                            }
                            Console.WriteLine("Player tidak ditemukan");
                            Console.ReadKey();
                            ;
                        }
                        else
                        {
                            Console.WriteLine("ID harus angka!");
                            Console.ReadKey();
                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if (player.name == data[0] || player.name!.ToLower() == data[0])
                            {
                                if (player.key == 0)
                                {
                                    newP = true;
                                    return player;
                                }
                                else
                                {
                                    return player;
                                }
                            }
                        }
                        Console.WriteLine("Player tidak ditemukan");
                        Console.ReadKey();
                    }

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("ID harus angka!");
                    Console.ReadKey();
                }
            }
        }
    }

}
