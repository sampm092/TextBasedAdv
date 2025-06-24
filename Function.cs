using System.Media;
using System.Diagnostics;
using System.Reflection;
namespace Kabur
{
    public class Function
    {
        static SoundPlayer typing;
        public static Random rand = new Random();
        public static void Print(string text, int speed = 40)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "sounds", "text.wav"); //https://pixabay.com/sound-effects/medium-text-blip-14855/

            if (OperatingSystem.IsWindows()) //checking if window
            {
                // typing = new SoundPlayer(path);
                // typing.PlayLooping();
                foreach (char c in text)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(speed);
                }
                // typing.Stop();
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

        public static int GetHealth()  //randomize enemy health
        {

            int upper = 2 * Program.player.mods + 7;
            int lower = Program.player.mods + 3;
            return rand.Next(lower, upper);
        }

        public static int GetPower() //randomize enemy power
        {
            int upper = 2 * Program.player.mods + 3;
            int lower = Program.player.mods + 1;
            return rand.Next(lower, upper);
        }

        public static int GetDefense() //randomize enemy power
        {
            int upper = 1 * Program.player.mods + 1;
            int lower = Program.player.mods;
            return rand.Next(lower, upper);
        }

        public static int GetMoney() //randomize money dropped
        {
            if (Program.player.position == 61 || Program.player.position == 611)
            {
                return 300;
            }
            else if (Program.player.position == 1)
            {
                return 500;
            }
            else
            {
                int upper = 15 * Program.player.mods + 10 * Program.player.level + 60;
                int lower = 10 * Program.player.mods + 5 * Program.player.level + 20;
                return rand.Next(lower, upper);
            }
        }

        public static int GetXP() //randomize money dropped
        {
            if (Program.player.position == 61 || Program.player.position == 611)
            {
                return 500;
            }
            else if (Program.player.position == 1)
            {
                return 750;
            }
            else
            {
                int upper = 25 * Program.player.mods + 45;
                int lower = 10 * Program.player.mods + 15;
                return rand.Next(lower, upper);
            }
        }

        public static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("888       888          888                                         ");
            Console.WriteLine("888   o   888          888                                         ");
            Console.WriteLine("888  d8b  888          888                                         ");
            Console.WriteLine("888 d888b 888  .d88b.  888  .d8888b .d88b.  88888b.d88b.   .d88b.  ");
            Console.WriteLine("888d88888b888 d8P  Y8b 888 d88P`   d88``88b 888 `888 `88b d8P  Y8b ");
            Console.WriteLine("88888P Y88888 88888888 888 888     888  888 888  888  888 88888888 ");
            Console.WriteLine("88888P   Y8888 Y8b.    888 Y88b.   Y88..88P 888  888  888 Y8b.     ");
            Console.WriteLine("888P     Y888  `Y8888  888  `Y8888P `Y88P`  888  888  888  `Y8888  ");
            Print(".    .    .    .    .    .    .    .    .    .    .    .    .    . ", 30);
        }
    }
}