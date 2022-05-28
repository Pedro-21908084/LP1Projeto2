namespace Game
{
    public class Boost : Tile
    {
        public Boost(Board board) : base( board, "🚀"){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{0,2}, player);
        }
    }
}