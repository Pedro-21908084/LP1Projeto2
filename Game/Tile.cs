using System;

namespace Game
{
    public class Tile
    {
        public Board board;
        private string icon;
        public bool IsSpecial{get; private set;}

        public Tile(Board board, string icon, bool isSpecial)
        {
            this.board = board;
            this.icon = icon;
            IsSpecial = isSpecial;
        }

        public virtual void Effect(Player player){}

        public override string ToString() => icon;
    }
}