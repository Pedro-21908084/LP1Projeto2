namespace Game
{
    public class Player
    {
        public int      X{get; set;}
        public int      Y{get; set;}
        public bool     CheatDice{get; set;}
        public bool     ExtraDice{get; set;}
        public string   Icon{get;}

        public Player(string icon)
        {
            Icon = icon;
            X = 0;
            Y = 4;
            CheatDice = false;
            ExtraDice = false;
        }

        public override string ToString()=> Icon;

    }
}