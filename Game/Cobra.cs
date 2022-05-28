namespace Game
{
    public class Cobra : Tile
    {
        public Cobra(Board board) : base( board, "🟥", true){}
        
        public override void Effect(Player player)
        {
            player.X = 4;
            player.Y = 0;
        }
    }
}