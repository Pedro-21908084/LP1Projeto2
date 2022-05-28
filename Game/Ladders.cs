namespace Game
{
    public class Ladders : Tile
    {
        public Ladders(Board board) : base( board, "La"){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{2,0}, player);
        }
    }
}