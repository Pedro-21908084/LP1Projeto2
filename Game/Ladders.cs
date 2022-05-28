namespace Game
{
    public class Ladders : Tile
    {
        public Ladders(Board board)
        {
            this.board = board;

            Icon = "La";
        }
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{2,0}, player);
        }
    }
}