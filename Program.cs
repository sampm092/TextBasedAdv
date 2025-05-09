namespace Out
{
    class Program
    {
        public static Player player = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Encounter.FirstEncounter();
            while (mainLoop)
            {
                Encounter.RandomEncounter();
            }
        }

        static void Start()
        {
            Console.Clear();
            Console.WriteLine("Kabur!`");

            while (true)
            {
                Console.WriteLine("Nama anda?");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    player.name = input;
                    break;
                }
                Console.WriteLine("Nama diperlukan!");
            }
            Console.Clear();
            Console.WriteLine("Kamu, " + player.name + ", menemukan diri terbangun di sebuah ruangan yang tak dikenal");
            Console.WriteLine("Kamu melihat sekitar yang ternyata dikelilingi oleh tembok batu yang terlihat kokoh dan sebuah pintu tampak diantaranya");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Kamu tidak mengerti apa yang terjadi hingga bisa berada di sini. Tetapi kamu tahu satu hal");
            Console.WriteLine("Kamu harus kabur dari tempat ini!");
            Console.ReadKey();
            Console.Clear();

        }
    }

}
