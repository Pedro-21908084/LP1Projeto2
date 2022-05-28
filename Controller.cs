using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 
{
    public class Controller
    {
        private List<Player> list;
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
            //Creates a new map instance 
            Map currentmap = new Map();
            /* Console.WriteLine($"New Game ----------- Starts New Game");
            Console.WriteLine($"Help --------------- Shows Possible Command Inputs");
            Console.WriteLine($"Throw Dice ----------Rolls the dice");
            Console.WriteLine($"Use Extra Dice ------Uses Extra Dice if it is available");
            Console.WriteLine($"Bonus Dice Info -----Shows What Each Bonus Dice does when used");
            Console.WriteLine($"Tile Info -----------Shows the effect of all the types of existing tiles");
            Console.WriteLine($"Back-----------------Goes Back to Main Menu");
            Console.WriteLine($"Quit-----------------Exit Game"); */
            ShowMainMenu();
            //The turn System from 1 to max lenght of player array
            for (int i = 0; i < players.Length; i++)
            {

                int playerTextNumber = i + 1;
                grid.ShowMap(players);
                //Shows visually the board map from new instance created above

                /* Console.WriteLine($"It's Player {i + 1} turn");
                Console.WriteLine($"Do you have Cheat Dice? {players[i].hasCheatDice}");
                Console.WriteLine($"Do you have Extra Dice? {players[i].hasExtraDice}"); */
                ShowInGameDisplay();

                //Waits for Player input
                string playerGameInput = Console.ReadLine();
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
            void WaitingInput()
            {
                Console.WriteLine($"Player {playerNumber + 1}, it's still your turn");
                playerInput = Console.ReadLine();
                CheckPlayerInput(playerInput, playerNumber, isInGame);
            }

            void WaitingMenuInput()
            {
                Console.WriteLine("What Next?");
                playerInput = Console.ReadLine();
                CheckPlayerInput(playerInput, playerNumber, isInGame);
            }
            //If is inside the TurnSystemLoop Checks these commands
            if (isInGame == true)
            {
                switch (playerInput)
                {
                    case "New Game":
                        Console.WriteLine("New Game Generated...");
                        grid = new Map();
                        players[0] = new Player(4, 0, false, false);
                        players[1] = new Player(4, 0, false, false);
                        TurnSystemLoop();
                        break;

                    case "Help":
                        /* Console.WriteLine($"New Game ----------- Starts New Game");
                        Console.WriteLine($"Help --------------- Shows " +
                            "Possible Command Inputs");
                        Console.WriteLine($"Throw Dice ----------Rolls the dice");
                        Console.WriteLine($"Use Extra Dice-------Uses the " +
                            "extra dice in case of having one");
                        Console.WriteLine($"Bonus Dice info------Shows the " +
                            "effects of using the Bonus Dices");
                        Console.WriteLine($"Tile Info -----------Shows the " +
                            "effect of all the types of existing tiles");
                        Console.WriteLine($"Quit-----------------Exit To Main Menu"); */
                        ShowInGameHelp();
                        WaitingForInput();
                        break;

                    case "Throw Dice":
                        int diceNumberGiven = ThrowDice();
                        Console.WriteLine($"Dice Rolled: {diceNumberGiven}");
                        if (players[playerNumber].hasCheatDice == true)
                            CheatDiceQuestion(playerNumber, diceNumberGiven);
                        else
                            players[playerNumber] = NextMove
                                (playerNumber, diceNumberGiven);
                        break;

                    case "Use Extra Dice":
                        if (players[playerNumber].hasExtraDice == true)
                        {
                            int extraDiceNumber = ThrowDice() + ThrowDice();
                            Console.WriteLine($"The sum of the 2 Dice was: {extraDiceNumber}");
                            players[playerNumber] = NextMove(playerNumber, extraDiceNumber);
                            players[playerNumber].hasExtraDice = false;
                        }
                        else
                        {
                            Console.WriteLine("No Extra Dice to use");
                            WaitingForInput();
                        }
                        break;

                    case "Bonus Dice Info":
                        /* Console.WriteLine("Using an Extra dice will roll 2 " + 
                            "dices at the same time and add both numbers");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine("Using an Cheat dice will grant the" +
                            " player the ability to choose a number and move " +
                            "a number of tiles according to that selected number");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------"); */
                        ShowBonusDiceInfo();
                        WaitingForInput();
                        break;

                    case "Tile Info":
                        /* Console.WriteLine($"Normal Tiles do not affect the " + 
                            "player position. They are represented by numbers");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine($"Snake Tiles make the player go " + 
                            "vertically down 1 tile. They are represented by " +
                            " this symbol: 🐍 ");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine($"Ladder Tiles make the player go " +
                            "vertically up 1 tile. They are represented by " +
                            "numbers by this symbol:冃 ");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine($"Cobra Tiles make the player go " +
                            "back to the first spot of the board. They are " +
                            "represented by this symbol: 🟥 ");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine($"Boost Tiles make the player go " +
                            "forward 2 tiles. They are represented by this " +
                            "symbol: 🚀 ");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine($"U-turn Tiles make the player go " +
                            "back 2 tiles. They are represented by this symbol: ↺ ");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine($"Extra Die Tiles grant the player" +
                            " an extra dice(If the player already has 1 " + 
                            "extra dice no more will be granted). They are " +
                            "represented by this symbol: ➕");
                        Console.WriteLine("---------------------------------" +
                            "-----------------------------------------------");
                        Console.WriteLine($"Cheat Die Tiles grant the player" +
                            " the option to choose a number and move a number" +
                            " of tiles using that number. They are " + 
                            "represented by this symbol: 🎲"); */
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
                        MainMenu();
                        WaitingMenuInput();
                        break;

                    case "Quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        WaitingMenuInput();
                        break;
                }
            }


        }
    }
}