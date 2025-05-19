namespace MyApp
{
    [Serializable]
    public class Player
    {
        Random rand = new Random();


        //get set is for json serialization
        public int id { get; set; }
        public string? name { get; set; }
        public int money { get; set; } = 70;
        public int maxHealth { get; set; } = 10;
        public int health { get; set; } = 10;
        public int attackValue { get; set; } = 1;
        public int defenseValue { get; set; } = 0;
        public int weaponValue { get; set; } = 1;
        public int potion { get; set; } = 3;
        public int mods { get; set; } = 0; //for modifying power level
        public int level { get; set; } = 1;
        public int exp { get; set; } = 0;

        public enum PLayerClass { Warrior, Knight, Alchemist }; //3 class for now
        public PLayerClass currentClass { get; set; } = PLayerClass.Warrior; //default class

        public int GetHealth()  //randomize enemy health
        {
            int upper = 2 * mods + 7;
            int lower = mods + 3;
            return rand.Next(lower, upper);
        }

        public int GetPower() //randomize enemy power
        {
            int upper = 2 * mods + 3;
            int lower = mods + 1;
            return rand.Next(lower, upper);
        }

        public int GetMoney() //randomize money dropped
        {
            int upper = 15 * mods + 50;
            int lower = 10 * mods + 10;
            return rand.Next(lower, upper);
        }

        public int GetXP() //randomize money dropped
        {
            int upper = 25 * mods + 45;
            int lower = 10 * mods + 15;
            return rand.Next(lower, upper);
        }

        public int LevelUpValue()
        {
            return 50 * level + 400;
        }

        public bool CanLevelUp()
        {
            if (exp >= LevelUpValue()) return true;
            else return false;
        }

        public void LevelUp()
        {
            while (CanLevelUp())
            {
                exp -= LevelUpValue();
                level++;
            }
            Program.Print("Kamu naik level menjadi level " + level + " !");
        }
    }
}