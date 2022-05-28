namespace Game
{
    public class UTurn : Tile
    {
        public UTurn(Board board) : base( board, "↺", true){}
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{0,-2}, player);
        }
    }
}