using System;

namespace Game
{
    public class Tile
    {
        public Board board;
        private string Icon;

        public Tile(Board board, string icon)
        {
            this.board = board;
            Icon = icon;
        }

        public virtual void Effect(Player player){}

        public override string ToString() => Icon;
    }
}