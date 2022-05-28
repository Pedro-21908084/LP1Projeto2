namespace Game
{
    public class Boost : Tile
    {
        public Boost(Board board) : base( board, "Bo", true){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{0,2}, player);
        }
    }
}