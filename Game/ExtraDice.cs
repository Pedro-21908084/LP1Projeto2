namespace Game
{
    public class ExtraDice : Tile
    {
        public ExtraDice(Board board)
        {
            this.board = board;

            Icon = "Ex";
        }
        
        public override void Effect(Player player)
        {
            player.ExtraDice = true;
        }
    }
}