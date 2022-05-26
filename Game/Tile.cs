using System;

namespace Game
{
    public class Tile
    {
        private Board board;
        private char Icon;

        public Tile(Board board, int indice)
        {
            this.board = board;
            Icon = ((char)indice);
        }

        public virtual void Effect(Player player)
        {
            
        }
    }
}