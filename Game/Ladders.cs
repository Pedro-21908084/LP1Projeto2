namespace Game
{
    public class Ladders : Tile
    {
        public Ladders(Board board) : base( board, "冃"){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{2,0}, player);
        }
    }
}