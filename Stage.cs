namespace MyApp
{
    public class Stage
    {
        static Dictionary<int, Room> map = new Dictionary<int, Room>
        {
            [0] = new Room
            {
                Id = 0,
                Description = "Pilih jalan yang ingin kamu lewati: \nKembali | Rest | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kembali"] = 31
                },
                Encounter = () => Encounter.RoomZero()
            },
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
                Description = "Pilih jalan yang ingin kamu lewati: \nKiri | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kiri"] = 0,
                    ["kanan"] = 31
                },
                Encounter = () => Encounter.ClearedEncounter()
            },
            [13] = new Room
            {
                Id = 13,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kiri | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kiri"] = 21,
                    ["maju"] = 0
                },
                Encounter = () => Encounter.ClearedEncounter()
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
                Encounter = () => Encounter.RandomEncounter()
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
                Encounter = () => Encounter.SecondEncounter() //fix double encounter issue
            },
            [33] = new Room
            {
                Id = 33,
                Description = "Pilih jalan yang ingin kamu lewati: \nKiri | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kiri"] = 22,
                    ["kanan"] = 13
                },
                Encounter = () => Encounter.ClearedEncounter()
            },
            [41] = new Room
            {
                Id = 41,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 43,
                    ["kanan"] = 51
                },
                Encounter = () => Encounter.ThirdEncounter()
            },
            [42] = new Room
            {
                Id = 42,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kiri | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 33,
                    ["kiri"] = 51
                },
                Encounter = () => Encounter.ClearedEncounter()
            },
            [43] = new Room
            {
                Id = 43,
                Description = "Pilih jalan yang ingin kamu lewati: \nKiri | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["kiri"] = 33,
                    ["kanan"] = 42
                },
                Encounter = () => Encounter.ChestEncounter2()
            },
            [51] = new Room
            {
                Id = 51,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kiri | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 61,
                    ["kiri"] = 52,
                    ["kanan"] = 54
                },
                Encounter = () => Encounter.FouthEncounter()
            },
            [52] = new Room
            {
                Id = 52,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kiri | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 54,
                    ["kiri"] = 61,
                    ["kanan"] = 43
                },
                Encounter = () => Encounter.RandomEncounter()
            },
            [53] = new Room
            {
                Id = 53,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kiri | Kanan | Kembali | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 43,
                    ["kiri"] = 54,
                    ["kanan"] = 52,
                    ["kembali"] = 61 //could be simplified, without the dialogue
                },
                Encounter = () => Encounter.ClearedEncounter()
            },
            [54] = new Room
            {
                Id = 54,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kiri | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 52,
                    ["kiri"] = 43,
                    ["kanan"] = 61
                },
                Encounter = () => Encounter.ChestEncounter()
            },
            [61] = new Room
            {
                Id = 61,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kembali | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 1,
                    ["kembali"] = 53
                },
                Encounter = () => Encounter.FifthEncounter()
            },

            [1] = new Room //boss room
            {
                Id = 1,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kembali | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 1, //bingung
                    ["kembali"] = 53 //bingung
                },
                Encounter = () => Encounter.FouthEncounter() //boss encounter
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

                if (input == "rest")
                {
                    Console.Clear();
                    Program.player.health = Program.player.maxHealth;
                    Function.Print("Kamu beristirahat untuk memulihkan kembali tenagamu.", 15);
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (currentRoom.Paths.TryGetValue(input, out int nextPosition))
                {
                    Program.player.position = nextPosition; // Move first
                    Room nextRoom = map[nextPosition];      // Get the new room
                    if (nextPosition != 61 && !Program.player.VisitedRooms.Contains(nextPosition))
                    {
                        nextRoom.Encounter?.Invoke(); // First-time special encounter
                        Program.player.VisitedRooms.Add(nextPosition);      // Mark as visited 

                        if (Program.player.VisitedRooms.Overlaps(new[] { 31, 32 }))
                        {
                            Program.player.VisitedRooms.Add(31);
                            Program.player.VisitedRooms.Add(32);
                        }
                    }
                    else if(nextPosition == 61)
                    {
                        nextRoom.Encounter?.Invoke();
                    }
                    else
                    {
                        Encounter.ClearedEncounter(); // For repeated visits
                    }
                    currentRoom = nextRoom;
                }
                else
                {
                    Function.Print("Masukkan input sesuai pilihan!");
                    Console.Clear();
                }
            }
        }
    }
}

