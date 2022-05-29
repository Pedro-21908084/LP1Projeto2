namespace Game
{
    public class CheatDice : Tile
    {
        public CheatDice(Board board) : base( board, "🎲", true){}
        
        public override void Effect(Player player)
        {
            player.CheatDice = true;

            int playerNum = (player.Icon == board.players[0].Icon)? 0 : 
                (player.Icon == board.players[1].Icon)? 1 : -1;
            if(playerNum != -1)
                board.AddToTurn($"\nPlayer {playerNum+1} gained a cheat " + 
                "dice if he already didn't had one");
        }
    }
}