using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class Controller
    {
        private TheView view;
        private Board board;

        private SaveSystem saveSystem;

        private bool isInGame;

        public Controller(TheView theView, Board theBoard, SaveSystem theSaveSystem)
        {
            view = theView;
            board = theBoard;
            saveSystem =theSaveSystem;
        }
        /// <summary>
        /// Runs The Game
        /// </summary>
        /// <param name="theView"></param>
        public void RunGame(TheView theView)
        {
            view.ShowMainMenu();
            view.WaitingForInput();
            CheckPlayerInput(view.PlayerInput,-1, isInGame, board);
        }
                
        /// <summary>
        /// Starts the game loop going through turns based on the number of 
        /// players in the array
        /// </summary>
        private void TurnSystemLoop()
        {
            //Checks if is in the game to help the CheckPlayerInput method see 
            //what commands are available
            bool isInGame = true;
            view.ShowInGameDisplay(board);
            //The turn System from 1 to max length of player array
            for (int i = 0; i < board.players.Length; i++)
            {
                view.ShowBoard(board);
                view.ShowPlayerMoves(board);
                board.ResetTurnMsg();
                int winnerResult = board.CheckWinner();
                if(winnerResult != 0)
                {
                    view.ShowWinMessage(winnerResult);
                    view.ShowMainMenu();
                    isInGame = false;
                    view.WaitingForInput();
                    CheckPlayerInput(view.PlayerInput,winnerResult,isInGame,board);
                    break;
                }

                view.ShowPlayerUI(board, i + 1);
                //Waits for Player input
                view.WaitingForInput();
                //Checks if the player input is equal to one of the commands 
                //specified in the function and plays out the proper action
                CheckPlayerInput(view.PlayerInput,i,isInGame,board);
                //When the turn number is 1 it resets back to -1 for the 
                //repetition of the loop
                if (i == 1)
                    i = -1;
            }

        }

        /// <summary>
        /// Waits and Checks what the player inputs while in the game or in 
        /// the main menu and gives/plays out the proper response or action 
        /// </summary>
        /// <param name="playerInput"></param>
        /// <param name="playerNumber"></param>
        /// <param name="isInGame"></param>
        private void CheckPlayerInput(string playerInput, int playerNumber, bool isInGame, Board theBoard)
        {
            if (isInGame == true)
            {
                switch (playerInput)
                {

                    case "1":
                        Player player1 = new Player("🧑");
                        Player player2 = new Player("👩");
                        board = new Board(player1,player2);
                        saveSystem.DeleteSaveFile();
                        TurnSystemLoop();
                        break;

                    case "2":
                        view.ShowInGameHelp();
                        view.WaitingForInput();
                        CheckPlayerInput(view.PlayerInput, playerNumber, isInGame, theBoard);
                        break;

                    case "3":
                        int diceNumberGiven = theBoard.ThrowDice();
                        view.ShowDiceRoll(diceNumberGiven);
                        if (theBoard.players[playerNumber].CheatDice == true)
                        {
                            CheatDiceQuestion(theBoard,playerNumber,diceNumberGiven);
                        }
                        else
                            theBoard.Move(new int[]{0, diceNumberGiven},theBoard.players[playerNumber]);
                        break;

                    case "4":
                        if (theBoard.players[playerNumber].ExtraDice == true)
                        {
                            int extraDiceNumber = theBoard.ThrowDice() + theBoard.ThrowDice();
                            view.ShowExtraDiceResult(extraDiceNumber);
                            theBoard.Move(new int[]{0, extraDiceNumber},theBoard.players[playerNumber]);
                            theBoard.players[playerNumber].ExtraDice = false;
                        }
                        else
                        {
                            view.ShowExtraDiceError();
                            view.WaitingForInput();
                            CheckPlayerInput(view.PlayerInput,playerNumber,isInGame,theBoard);
                        }
                        break;

                    case "5":
                        view.ShowBonusDiceInfo();
                        view.WaitingForInput();
                        CheckPlayerInput(view.PlayerInput,playerNumber,isInGame,theBoard);
                        break;

                    case "6":
                        view.ShowTileInfo();
                        view.WaitingForInput();
                        CheckPlayerInput(view.PlayerInput,playerNumber,isInGame,theBoard);
                        break;

                    case "7":
                        saveSystem.Save(board);
                        isInGame = false;
                        view.ShowMainMenu();
                        view.WaitingForInput();
                        CheckPlayerInput(view.PlayerInput,playerNumber,isInGame,theBoard);
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        view.ErrorMessage();
                        view.WaitingForInput();
                        CheckPlayerInput(view.PlayerInput,playerNumber,isInGame,theBoard);
                        break;
                }
            }
            //If is in the Main Menu and not inside the TurnSystemLoop then checks these commands
            else if (isInGame == false)
            {
                switch (playerInput)
                {
                    case "1":
                        Player player1 = new Player("🧑");
                        Player player2 = new Player("👩");
                        board = new Board(player1,player2);
                        saveSystem.DeleteSaveFile();
                        TurnSystemLoop();
                        break;

                    case "2":
                        bool loadFileStatus = saveSystem.Load(board);
                        if(loadFileStatus)
                        {
                            TurnSystemLoop();
                        }
                        else
                        {
                            view.LoadErrorMessage();
                            view.WaitingForInput();
                            CheckPlayerInput(view.PlayerInput,playerNumber,isInGame,board);
                        }
                        
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        view.ErrorMessage();
                        view.WaitingForInput();
                        CheckPlayerInput(view.PlayerInput,-1, isInGame,board);
                        break;
                }
            }


        }
        
        /// <summary>
        /// Question for cheat dice case with options included
        /// </summary>
        /// <param name="theBoard"></param>
        /// <param name="playerNumber"></param>
        /// <param name="diceRollNumber"></param>
        private void CheatDiceQuestion(Board theBoard, int playerNumber, int diceRollNumber)
        {
            string theAnswer = view.AskCheatDiceQuestion();
            if(theAnswer == "1")
            {
                int rollAnswer = view.AskCheatDiceRoll();
                if (rollAnswer >= 1 && rollAnswer <= 6)
                {
                 theBoard.Move(new int[]{0, rollAnswer},theBoard.players[playerNumber]);
                 theBoard.players[playerNumber].CheatDice = false;
                }
                else
                {
                    CheatDiceQuestion(board,playerNumber,diceRollNumber);
                }
            }
            else if(theAnswer == "2")
            {
                theBoard.Move(new int[]{0, diceRollNumber},theBoard.players[playerNumber]);
            }
            else
            {
                view.ErrorMessage();
                CheatDiceQuestion(board,playerNumber,diceRollNumber);
            }
        }
    }
}