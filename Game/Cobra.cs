namespace Game
{
    public class Cobra : Tile
    {
        public Cobra(Board board)
        {
            this.board = board;

            Icon = "Co";
        }
        
        public override void Effect(Player player)
        {
            player.X = 4;
            player.Y = 0;
        }
    }
}