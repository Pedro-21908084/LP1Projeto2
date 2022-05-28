using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public interface IView
    {
        //Variables/Properties
        public string PlayerInput {get; set;}

        //Methods
        public void ShowMainMenu();
        
        public void ShowInGameDisplay(Board board, Player player1, Player player2);

        public void ShowInGameHelp();

        public void ShowBonusDiceInfo();

        public void ShowTileInfo();

        public void WaitingForInput();

        public void ShowBoard(Board board, Player player1, Player player2);

        public void ShowPlayerMoves(Board board);

        public void ShowDiceRoll(int diceRollNumber);

        public void ShowExtraDiceResult(int sumOfDicesRoll);

        public void ShowExtraDiceError();

        public void AskCheatDiceQuestion();

        public int AskCheatDiceRoll();

        public void ShowOutOfBoundsMessage(int numberOfTilesOver25);

        public void ShowWinMessage(int playerNumber);

        public void ShowPlayerNumber(int playerNumber);

        public void ErrorMessage();

    }
}