using System;

namespace Game
{
    public class Tile
    {
        private Board board;
        private string Icon;

        public Tile(Board board, int indice)
        {
            this.board = board;
            Icon = indice.ToString();
        }

        public virtual void Effect(Player player){}

        public override string ToString() => Icon;
    }
}