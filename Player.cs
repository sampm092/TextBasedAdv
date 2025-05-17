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
        public int maxHealth { get; set; } = 10+ ((Program.player.currentClass==PLayerClass.Alchemist)?+4:0);
        public int health { get; set; } = 10;
        public int attackValue { get; set; } = 1;
        public int defenseValue { get; set; } = 0 + ((Program.player.currentClass==PLayerClass.Knight)?+2:0);
        public int weaponValue { get; set; } = 1 + ((Program.player.currentClass==PLayerClass.Warrior)?+2:0);
        public int potion { get; set; } = 3 + + ((Program.player.currentClass==PLayerClass.Alchemist)?+2:0);

        public int mods { get; set; } = 0; //for modifying power level

        public enum PLayerClass {Warrior, Knight, Alchemist};
        public PLayerClass currentClass {get;set;} = PLayerClass.Warrior;

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
    }
}