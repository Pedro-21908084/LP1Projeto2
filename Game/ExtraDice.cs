namespace Game
{
    public class ExtraDice : Tile
    {
        public ExtraDice(Board board) : base( board, "➕"){}
        
        public override void Effect(Player player)
        {
            player.ExtraDice = true;
        }
    }
}