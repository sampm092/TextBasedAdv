using System.Diagnostics.Tracing;

namespace MyApp
{
    [Serializable]
    public class Player
    {
        //get set is for json serialization
        public int id { get; set; }
        public string? name { get; set; }
        public int money { get; set; } = 70;
        public int maxHealth { get; set; } = 10;
        public int health { get; set; } = 10;
        public int attackValue { get; set; } = 1;
        public int defenseValue { get; set; } = 0 ;
        public int weaponValue { get; set; } = 1;
        public int potion { get; set; } = 3;
        public int mods { get; set; } = 0; //for modifying power level
        public int level { get; set; } = 1;
        public int exp { get; set; } = 50;
        public int key { get; set; } = 0;
        public int position { get; set; } = 0;
        public HashSet<int> VisitedRooms { get; set; } = new HashSet<int>(); // for repetitive feature


        public enum PLayerClass { Warrior, Knight, Alchemist }; //3 class for now
        public PLayerClass currentClass { get; set; } = PLayerClass.Warrior; //default class

        public int LevelUpValue()
        {
            return 75 * level; //exp needed for level up
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
                exp -= LevelUpValue(); //resetting the exp value after Level Up
                level++;
            }
            maxHealth++;
            Function.Print("Kamu naik level menjadi level " + level + " !");
            Function.Print("Maks darah naik menjadi " + maxHealth + " !");
            if (level % 2 == 1)
            {
                attackValue++;
                defenseValue++;
                 int attackrange = Program.player.weaponValue + Program.player.attackValue;
                Function.Print("Kekuatan serangan menjadi " + attackrange + " !");
                Function.Print("Ketahanan menjadi " + defenseValue + " !");
            }
        }
    }
}