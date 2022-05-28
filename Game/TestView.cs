namespace Game
{
    public class TestView : IView
    {
        public string PlayerInput { get; set; }

        public void ShowBoard(Board board, Player player1, Player player2)
        {
            
        }

        public void ShowInGameDisplay(Board board, Player player1, Player player2)
        {}

        public void ShowBonusDiceInfo()
        {

        }

        public void ShowInGameDisplay()
        {

        }

        public void ShowInGameHelp()
        {

        }

        public void ShowMainMenu()
        {

        }

        public void ShowPlayerMoves()
        {

        }

        public void ShowTileInfo()
        {

        }

        public string WaitingForInput(string playerInput)
        {
            return playerInput;
        }
    }
}