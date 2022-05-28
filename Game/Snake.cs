namespace Game
{
    public class Snake : Tile
    {
        public Snake(Board board) : base( board, "🐍", true){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{-1,0}, player);
        }
    }
}