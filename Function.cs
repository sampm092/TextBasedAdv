using System.Media;
namespace MyApp
{
    public class Function
    {

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