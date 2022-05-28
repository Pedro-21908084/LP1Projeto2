using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 
{
    public class Controller
    {
        private IView view;
        private Board board;

                //Controller
        /// <summary>
        /// Starts the game loop going through turns based on the number of 
        /// players in the array
        /// </summary>
        private void TurnSystemLoop()
        {
            //Checks if is in the game to help the CheckPlayerInput method see 
            //what commands are available
            bool isInTheGame = true;
            ShowInGameDisplay();
            //The turn System from 1 to max length of player array
            for (int i = 0; i < players.Length; i++)
            {

                int playerTextNumber = i + 1;
                grid.ShowMap(players);
                //Shows visually the board map from new instance created above
                ShowInGameDisplay();

                //Waits for Player input
                //string playerGameInput = Console.ReadLine();
                WaitingForInput();
                //Checks if the player input is equal to one of the commands 
                //specified in the function and plays out the proper action
                CheckPlayerInput(playerGameInput, i, isInTheGame);
                //When the turn number is 1 it resets back to -1 for the 
                //repetition of the loop
                if (i == 1)
                    i = -1;
            }

        }

        //Controller
        /// <summary>
        /// Waits and Checks what the player inputs while in the game or in 
        /// the main menu and gives/plays out the proper response or action 
        /// </summary>
        /// <param name="playerInput"></param>
        /// <param name="playerNumber"></param>
        /// <param name="isInGame"></param>
        private void CheckPlayerInput(string playerInput, int playerNumber, bool isInGame)
        {

            /// <summary>
            /// Waits for the player input and checks again what it was
            /// </summary>
            //If is inside the TurnSystemLoop Checks these commands
            if (isInGame == true)
            {
                switch (playerInput)
                {

                    case "New Game":
                    //TODO New game case in view
                        //Console.WriteLine("New Game Generated...");
                        grid = new Map();
                        players[0] = new Player(4, 0, false, false);
                        players[1] = new Player(4, 0, false, false);
                        TurnSystemLoop();
                        break;

                    case "Help":
                        ShowInGameHelp();
                        WaitingForInput();
                        break;

                    case "Throw Dice":
                    //TODO Throw dice /Cheat dice case in view
                        int diceNumberGiven = Board.ThrowDice();
                        //Console.WriteLine($"Dice Rolled: {diceNumberGiven}");
                        if (players[playerNumber].hasCheatDice == true)
                            CheatDiceQuestion(playerNumber, diceNumberGiven);
                        else
                            players[playerNumber] = NextMove
                                (playerNumber, diceNumberGiven);
                        break;

                    case "Use Extra Dice":
                    //TODO Extra dice case in view
                        if (players[playerNumber].hasExtraDice == true)
                        {
                            int extraDiceNumber = ThrowDice() + ThrowDice();
                            //Console.WriteLine($"The sum of the 2 Dice was: {extraDiceNumber}");
                            players[playerNumber] = Board.Move(new int[] {0, extraDiceNumber}, Player player);
                            players[playerNumber].hasExtraDice = false;
                        }
                        else
                        {
                            Console.WriteLine("No Extra Dice to use");
                            WaitingForInput();
                        }
                        break;

                    case "Bonus Dice Info":
                        ShowBonusDiceInfo();
                        WaitingForInput();
                        break;

                    case "Tile Info":
                        ShowTileInfo();
                        WaitingForInput();
                        break;

                    case "Back":
                        ShowMainMenu();
                        break;

                    case "Quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        WaitingForInput();
                        break;
                }
            }
            //If is in the Main Menu and not inside the TurnSystemLoop then checks these commands
            else if (isInGame == false)
            {
                switch (playerInput)
                {
                    case "Start Game":
                        TurnSystemLoop();
                        break;

                    case "Help":
                        ShowInGameHelp();
                        WaitingMenuInput();
                        break;

                    case "Quit":
                        Environment.Exit(0);
                        break;

                    default:
                    //TODO case for invalid input
                        //Console.WriteLine("Invalid Input");
                        WaitingMenuInput();
                        break;
                }
            }


        }
    }
}