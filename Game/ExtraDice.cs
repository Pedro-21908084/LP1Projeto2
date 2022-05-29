namespace Game
{
    public class ExtraDice : Tile
    {
        public ExtraDice(Board board) : base( board, "➕", true){}
        
        public override void Effect(Player player)
        {
            player.ExtraDice = true;

            int playerNum = (player.Icon == board.players[0].Icon)? 0 : 
                (player.Icon == board.players[1].Icon)? 1 : -1;
            if(playerNum != -1)
                board.AddToTurn($"\nPlayer {playerNum+1} gained a Extra " + 
                "dice if he already didn't had one");
        }
    }
}