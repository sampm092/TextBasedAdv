using System.Text.Json;
using System.Media;
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
            Print("Pilih jalan yang ingin kamu lewati: ", 15);
            Console.WriteLine("Maju | Kanan | Shop");
            string input1 = Console.ReadLine()!.ToLower();
                if (input1 == "maju")
                {
                    Encounter.SecondEncounter();
                    break;
                }
                else if (input1 == "kanan")
                {
                    Print("Ruangan ini sepertinya hanya ruangan biasa.", 15);
                    Console.ReadKey();
                    Encounter.RandomEncounter();
                    break;
                }
                else if (input1 == "shop")
                {
                    Shop.LoadShop(player);
                    Console.Clear();
                    // break;
                }
                else
                {
                    Print("Masukkan input sesuai pilihan!");
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
            Print("Kabur!`", 50);

            while (true)
            {
                Print("Namamu?", 50);
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
                        Print("Pilih kelas yang tersedia!");
                        Flag = false;
                    }

                }
                Console.WriteLine("Tolong masukkan kelas!");
            }

            Console.Clear();
            Print("Kamu, " + p.name + ", menemukan diri terbangun di sebuah ruangan yang tak dikenal.", 15);
            Print("Kamu melihat sekitar yang ternyata dikelilingi oleh tembok batu yang terlihat kokoh ", 15);
            Print("dan sebuah pintu tampak diantaranya.",15);
            Console.ReadKey();
            Console.Clear();
            Print("Kamu tidak mengerti apa yang terjadi hingga bisa berada di sini. Tetapi kamu tahu satu hal", 15);
            Print("Tempat ini berbahaya dan kamu harus kabur dari tempat ini!", 15);
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
                                    return player;
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
                                return player;
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

        public static void Print(string text, int speed = 40)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "sounds", "text.wav"); //https://pixabay.com/sound-effects/medium-text-blip-14855/

            if (OperatingSystem.IsWindows()) //checking if window
            {
                SoundPlayer player = new SoundPlayer(path);
                player.PlayLooping();
                foreach (char c in text)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(speed);
                }
                player.Stop();
            }
            Console.WriteLine();
        }

        public static void ProgressBar(string barSymbol, decimal value, int size)//size for the amount of progress bar, value for the exp value
        {
            int differ = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < differ)
                    Console.Write(barSymbol);
                else
                    Console.Write("-");
            }

            // Result
            // Exp :
            // [========================-]
        }
    }

}
