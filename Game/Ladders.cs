namespace Game
{
    public class Ladders : Tile
    {
        public Ladders(Board board) : base( board, "冃", true){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{1,0}, player);
        }
    }
}