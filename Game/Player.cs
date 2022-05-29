namespace Game
{
    public class Player
    {
        public int      X{get; set;}
        public int      Y{get; set;}
        public bool     CheatDice{get; set;}
        public bool     ExtraDice{get; set;}
        public string   Icon{get;}

        /// <summary>
        /// Constructor for class player, sets the player icon with the icon
        /// given and sets his position to the start of the board and resets
        /// his cheat and extra dices.
        /// </summary>
        /// <param name="icon"></param>
        public Player(string icon)
        {
            //sets icon
            Icon = icon;

            //sets position
            X = 4;
            Y = 0;

            //resets cheat and extra dice
            CheatDice = false;
            ExtraDice = false;
        }

        public override string ToString()=> Icon;

    }
}