namespace Out
{
    [Serializable]
    public class Player
    {
        Random rand = new Random();


        //get set is for json serialization
        public int id { get; set; }
        public string? name { get; set; }
        public int money { get; set; } = 10000;
        public int maxHealth { get; set; } = 10;
        public int health { get; set; } = 10;
        public int attackValue { get; set; } = 1;
        public int defenseValue { get; set; } = 0;
        public int weaponValue { get; set; } = 1;
        public int potion { get; set; } = 3;

        public int mods { get; set; } = 0; //for modifying power level

        public int GetHealth()
        {
            int upper = 2 * mods + 7;
            int lower = mods + 3;
            return rand.Next(lower, upper);
        }

        public int GetPower()
        {
            int upper = 2 * mods + 3;
            int lower = mods + 1;
            return rand.Next(lower, upper);
        }

        public int GetMoney()
        {
            int upper = 15 * mods + 50;
            int lower = 10 * mods + 10;
            return rand.Next(lower, upper);
        }
    }
}