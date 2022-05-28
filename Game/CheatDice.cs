namespace Game
{
    public class CheatDice : Tile
    {
        public CheatDice(Board board) : base( board, "🎲"){}
        
        public override void Effect(Player player)
        {
            player.CheatDice = true;
        }
    }
}