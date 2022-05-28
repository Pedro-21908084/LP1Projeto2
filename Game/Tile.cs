using System;

namespace Game
{
    public class Tile
    {
        public Board board;
        private string icon;
        public bool IsSpecial{get; private set;}

        /// <summary>
        /// Constructor for class Tile, that sets his board, icon and if is 
        /// a special tile or not
        /// </summary>
        /// <param name="board"></param>
        /// <param name="icon"></param>
        /// <param name="isSpecial"></param>
        public Tile(Board board, string icon, bool isSpecial)
        {
            this.board = board;
            this.icon = icon;
            IsSpecial = isSpecial;
        }

        /// <summary>
        /// The effect that happens when a player stops on this tile, nothing
        /// happens in the base class tile
        /// </summary>
        /// <param name="player"></param>
        public virtual void Effect(Player player){}

        public override string ToString() => icon;
    }
}