namespace MyApp
{
    public class Stage
    {
        static Dictionary<int, Room> map = new Dictionary<int, Room>
        {
            [11] = new Room
            {
                Id = 11,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 31,
                    ["kanan"] = 21
                },
                Encounter = () => Encounter.RandomEncounter()
            },
            [12] = new Room
            {
                Id = 12,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kiri"] = 0,
                    ["kanan"] = 31
                },
                Encounter = () => Encounter.RandomEncounter()
            },
            [21] = new Room
            {
                Id = 21,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kiri | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 23,
                    ["kiri"] = 32
                },
                Encounter = () => Encounter.SecondEncounter()
            },
            [22] = new Room
            {
                Id = 22,
                Description = "Pilih jalan yang ingin kamu lewati: \nKanan | Kiri | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kanan"] = 12,
                    ["kiri"] = 23
                },
                Encounter = () => Encounter.RandomEncounter()
            },
            [23] = new Room
            {
                Id = 23,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 12,
                    ["kanan"] = 32
                },
                Encounter = () => Encounter.ChestEncounter()
            },
            [31] = new Room
            {
                Id = 31,
                Description = "Pilih jalan yang ingin kamu lewati: \nKiri | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kiri"] = 41,
                    ["kanan"] = 22
                },
                Encounter = () => Encounter.SecondEncounter()
            },
            [32] = new Room
            {
                Id = 32,
                Description = "Pilih jalan yang ingin kamu lewati: \nKiri | Maju | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kiri"] = 13,
                    ["maju"] = 41
                },
                Encounter = () => Encounter.SecondEncounter()
            },


        };

        public static void Stage1()
        {

            while (true)
            {
                var currentRoom = map[Program.player.position];
                Console.WriteLine(currentRoom.Description!);

                // Console.WriteLine(string.Join(" | ", currentRoom.Paths.Keys.Concat(new[] { "shop" })));
                string input = Console.ReadLine()!.ToLower();

                if (input == "shop")
                {
                    Shop.LoadShop(Program.player);
                    Console.Clear();
                    continue;
                }

                if (currentRoom.Paths.TryGetValue(input, out int nextPosition))
                {
                    Program.player.position = nextPosition; // Move first
                    Room nextRoom = map[nextPosition];      // Get the new room
                    if (!nextRoom.Visited)
                    {
                        nextRoom.Encounter?.Invoke(); // First-time special encounter
                        nextRoom.Visited = true;      // Mark as visited
                    }
                    else
                    {
                        Encounter.RandomEncounter(); // For repeated visits
                    }
                }
                else
                {
                    Function.Print("Masukkan input sesuai pilihan!");
                }
            }
        }
    }
}

