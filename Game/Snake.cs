namespace Game
{
    public class Snake : Tile
    {
        public Snake(Board board) : base( board, "Sn"){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{-2,0}, player);
        }
    }
}