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

        /// <summary>
        /// Shows the Main Menu 
        /// </summary>
        public void ShowMainMenu();
        
        /// <summary>
        /// Shows display of commands for usage when 
        /// first entering the TurnSystemLoop
        /// </summary>
        /// <param name="board"></param>
        public void ShowInGameDisplay(Board board);

        /// <summary>
        /// Shows all possible commands 
        /// </summary>
        public void ShowInGameHelp();

        /// <summary>
        /// Shows what the Special Dice do.
        /// </summary>
        public void ShowBonusDiceInfo();

        /// <summary>
        /// Shows what tiles means what and it's icon
        /// </summary>
        public void ShowTileInfo();

        /// <summary>
        /// Ask and waits for player input
        /// </summary>
        public void WaitingForInput();

        /// <summary>
        /// Shows the board
        /// </summary>
        /// <param name="board"></param>
        public void ShowBoard(Board board);

        /// <summary>
        /// Shows all player moves using board.Turn function
        /// </summary>
        /// <param name="board"></param>
        public void ShowPlayerMoves(Board board);

        /// <summary>
        /// Shows the number that rolled on the dice
        /// </summary>
        /// <param name="diceRollNumber">The dice number</param>
        public void ShowDiceRoll(int diceRollNumber);

        /// <summary>
        /// Shows the result of the two dices
        /// </summary>
        /// <param name="sumOfDicesRoll">The dices sum number</param>
        public void ShowExtraDiceResult(int sumOfDicesRoll);

        /// <summary>
        /// Shows error message of unavailable Extra Dice 
        /// </summary>
        public void ShowExtraDiceError();

        /// <summary>
        /// Asks the player, waits for answer and returns it
        /// </summary>
        /// <returns></returns>
        public string AskCheatDiceQuestion();

        
        /// <summary>
        /// Asks the player when he uses an Extra Dice, 
        /// waits for his input and returns it
        /// </summary>
        /// <returns></returns>
        public int AskCheatDiceRoll();

        /// <summary>
        /// Shows how many tiles outside of last position 
        /// of the board he went 
        /// </summary>
        /// <param name="numberOfTilesOver25">The number of tiles </param>
        public void ShowOutOfBoundsMessage(int numberOfTilesOver25);

        /// <summary>
        /// Shows Win message 
        /// </summary>
        /// <param name="playerNumber">The player number</param>
        public void ShowWinMessage(int playerNumber);

        /// <summary>
        /// Shows the whose turn it is, if the player has an extra dice and a cheat dice
        /// </summary>
        /// <param name="board">The board reference</param>
        /// <param name="playerNumber">The player number</param>
        public void ShowPlayerUI(Board board, int playerNUmber);

        public void LoadErrorMessage();

        /// <summary>
        /// Shows input error message
        /// </summary>
        public void ErrorMessage();

    }
}