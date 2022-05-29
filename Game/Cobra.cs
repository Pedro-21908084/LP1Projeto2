namespace Game
{
    public class Cobra : Tile
    {
        public Cobra(Board board) : base( board, "🟥", true){}
        
        public override void Effect(Player player)
        {
            player.X = 4;
            player.Y = 0;

            int playerNum = (player.Icon == board.players[0].Icon)? 0 : 
                (player.Icon == board.players[1].Icon)? 1 : -1;
            if(playerNum != -1)
                board.AddToTurn($"\nPlayer {playerNum+1} moved to the start");
        }
    }
}