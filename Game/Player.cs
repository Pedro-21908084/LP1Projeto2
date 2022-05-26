namespace Game
{
    public class Player
    {
        public int      X{get; set;}
        public int      Y{get; set;}
        public bool     CheatDice{get; set;}
        public bool     ExtraDice{get; set;}
        public char     Icon{get;}

        public Player(char icon)
        {
            Icon = icon;
            X = 0;
            Y = 4;
            CheatDice = false;
            ExtraDice = false;
        }

        public override string ToString()
        {
            return Icon.ToString();
        }
    }
}