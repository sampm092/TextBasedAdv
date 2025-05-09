namespace Out
{
    public class Player
    {
        Random rand = new Random();

        public string? name;
        public int money = 0;
        public int maxHealth = 10;
        public int health = 10;
        public int attackValue = 1;
        public int defenseValue = 0;
        public int weaponValue = 1;
        public int potion = 3;

        public int mods = 0; //for modifying power level

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
    }
}