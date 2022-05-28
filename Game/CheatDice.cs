namespace Game
{
    public class CheatDice : Tile
    {
        public CheatDice(Board board)
        {
            this.board = board;

            Icon = "Ch";
        }
        
        public override void Effect(Player player)
        {
            player.CheatDice = true;
        }
    }
}