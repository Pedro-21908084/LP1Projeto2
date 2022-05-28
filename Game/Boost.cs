namespace Game
{
    public class Boost : Tile
    {
        public Boost(Board board)
        {
            this.board = board;

            Icon = "Bo";
        }
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{0,2}, player);
        }
    }
}