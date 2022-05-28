using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class TheView:IView
    {
        //Variables/Properties
        public string PlayerInput {get; set;}

        //Methods
        public void ShowMainMenu()
        {
            Console.WriteLine("             ______________________________________________________");
            Console.WriteLine("            |Welcome To Snakes and Ladders: Command Console Edition|");
            Console.WriteLine(" ___________|______________________________________________________|___________");
            Console.WriteLine("| 1----------------------------------------------------------------Runs the game|");
            Console.WriteLine("| 2--------------------------------------------------Shows all Possible Commands|");
            Console.WriteLine("| 3--------------------------------------------------------------Loads Save Game|");
            Console.WriteLine("| 4-------------------------------------------------------------------Exits Game|");
            Console.WriteLine("|_______________________________________________________________________________|");

        }

        public void ShowInGameDisplay(Board board, Player player1, Player player2)
        {
            Console.WriteLine("Game Begun");
            Console.WriteLine("--------------------------------------------------------------------");
            ShowBoard(board, player1, player2);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("These are the possible inputs and what they do:");
            Console.WriteLine(" ");
            Console.WriteLine($"1 -----------------------------------------------Starts New Game");
            Console.WriteLine($"2 ------------------------------------Help(Show Possible Inputs)");
            Console.WriteLine($"3 ------------------------------------------------Rolls the dice");
            Console.WriteLine($"4 ----------------------------Uses Extra Dice if it is available");
            Console.WriteLine($"5 ---------------------Shows What Each Bonus Dice does when used");
            Console.WriteLine($"6 -----------Shows the effect of all the types of existing tiles");
            Console.WriteLine($"7-----------------------------------------Goes Back to Main Menu");
            Console.WriteLine($"8------------------------------------------------------Save Game");
            Console.WriteLine($"0------------------------------------------------------Exit Game");
            Console.WriteLine("-----------------------------------------------------------------");
            WaitingForInput(PlayerInput);
        }
        
        public void ShowInGameHelp()
        {
            Console.WriteLine($"1 -----------------------------------------------Starts New Game");
            Console.WriteLine($"2 ------------------------------------Help(Show Possible Inputs)");
            Console.WriteLine($"3 ------------------------------------------------Rolls the dice");
            Console.WriteLine($"4 ----------------------------Uses Extra Dice if it is available");
            Console.WriteLine($"5 ---------------------Shows What Each Bonus Dice does when used");
            Console.WriteLine($"6 -----------Shows the effect of all the types of existing tiles");
            Console.WriteLine($"7-----------------------------------------Goes Back to Main Menu");
            Console.WriteLine($"8------------------------------------------------------Save Game");
            Console.WriteLine($"0------------------------------------------------------Exit Game");
            Console.WriteLine("-----------------------------------------------------------------");
            WaitingForInput(PlayerInput);
        }

        public void ShowBonusDiceInfo()
        {
            Console.WriteLine("Using an Extra dice will roll 2 " + 
            "dices at the same time and add both numbers");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine("Using an Cheat dice will grant the" +
            " player the ability to choose a number and move " +
            "a number of tiles according to that selected number");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            WaitingForInput(PlayerInput);
        }

        public void ShowTileInfo()
        {
            Console.WriteLine($"Normal Tiles do not affect the " + 
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
            "represented by this symbol: 🎲");
            Console.WriteLine("-----------------------------------------------------------------");
            WaitingForInput(PlayerInput);
        }

        public string WaitingForInput(string playerInput)
        {
            Console.WriteLine("What do you want to do?");
            playerInput = Console.ReadLine();
            return playerInput;
        }

        public void ShowBoard(Board board, Player player1, Player player2)
        {
            Console.WriteLine("______________________________");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("|    ||    ||    ||    ||    |");
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("|");
                    if(board.Map[i,j].ToString().Length == 1)
                    {
                        Console.Write(" ");
                    }
                    else if(i == 4 && j == 0)
                    {
                        
                    }
                    Console.Write($" {board.Map[i,j]} |");
                }
                Console.WriteLine("\n|____||____||____||____||____|");
            }
        }

        public void ShowPlayerMoves()
        {

        }

    }
}