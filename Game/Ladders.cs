namespace Game
{
    public class Ladders : Tile
    {
        public Ladders(Board board) : base( board, "La", true){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{2,0}, player);
        }
    }
}