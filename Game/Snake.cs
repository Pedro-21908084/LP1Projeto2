namespace Game
{
    public class Snake : Tile
    {
        public Snake(Board board)
        {
            this.board = board;

            Icon = "Sn";
        }
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{-2,0}, player);
        }
    }
}