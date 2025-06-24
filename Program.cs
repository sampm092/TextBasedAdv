using System.Text.Json;
using System.Media;

namespace Kabur
{
    public class Program
    {
        static SoundPlayer song;
        static SoundPlayer into;
        public static Player player = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            Function.Welcome();
            string soundtrackStart = Path.Combine(AppContext.BaseDirectory, "sounds", "IntoTheDungeon.wav");
            into = new SoundPlayer(soundtrackStart);
            into.PlayLooping();
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }

            string soundtrack = Path.Combine(AppContext.BaseDirectory, "sounds", "one.wav");
            song = new SoundPlayer(soundtrack);

            player = Load(out bool newP);
            // song.PlayLooping();
            if (newP == true) { Encounter.FirstEncounter(); }
            Stage.Stage1();

        }

        static Player NewStart(int i)
        {
            Player p = new Player();
            Console.Clear();

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
            song.PlayLooping();
            Function.Print("Kamu, " + p.name + ", menemukan diri terbangun di sebuah ruangan yang tak dikenal.", 15);
            Function.Print("Kamu melihat sekitar yang ternyata dikelilingi oleh tembok batu yang terlihat kokoh ", 15);
            Function.Print("dan sebuah pintu tampak diantaranya.", 15);
            Console.ReadKey();
            Console.Clear();
            Function.Print("Kamu tidak mengerti apa yang terjadi hingga bisa berada di sini.", 15);
            Function.Print("Tetapi kamu tahu satu hal. Kamu harus keluar dari tempat ini!", 15);
            Console.ReadKey();
            Console.Clear();
            return p;

        }

        public static void Quit()
        {
            Save();
            Console.ReadKey();
            player = Load(out bool newP);
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
            Console.WriteLine("88  dP    db    88''Yb 88   88 88''Yb     d8b ");
            Console.WriteLine("88odP    dPYb   88__dP 88   88 88__dP     Y8P");
            Console.WriteLine("88`Yb   dP__Yb  88``Yb Y8   8P 88`Yb      ``' ");
            Console.WriteLine("88  Yb dP````Yb 88oodP `YbodP' 88  Yb     (8) ");
            Console.WriteLine("\nKarakter: ");
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;
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
                Console.Clear();

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
