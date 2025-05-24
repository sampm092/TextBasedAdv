namespace MyApp
{
    public class Stage
    {
        static Dictionary<int, Room> map = new Dictionary<int, Room>
        {
            [11] = new Room
            {
                Id = 11,
                Description = "Pilih jalan yang ingin kamu lewati: Maju | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 31,
                    ["kanan"] = 21
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
            [23] = new Room
            {
                Id = 23,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    ["maju"] = 11,
                    ["kanan"] = 32
                },
                Encounter = () => Encounter.SecondEncounter()
            },
            [31] = new Room
            {
                Id = 31,
                Description = "Pilih jalan yang ingin kamu lewati: \nMaju | Kanan | Shop",
                Paths = new Dictionary<string, int>
                {
                    // Add transitions here
                }
            },
            // Add more rooms...
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
                    currentRoom.Encounter?.Invoke();
                    Program.player.position = nextPosition;
                }
                else
                {
                    Function.Print("Masukkan input sesuai pilihan!");
                }
            }
        }
    }
}

