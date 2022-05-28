namespace Game
{
    public class UTurn : Tile
    {
        public UTurn(Board board)
        {
            this.board = board;

            Icon = "Ut";
        }
        
        public override void Effect(Player player)
        {
            board.Move(new int[]{0,-2}, player);
        }
    }
}