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
            Console.WriteLine("| 3---------------------------------------------------------------Exits the Game|");
            Console.WriteLine("|_______________________________________________________________________________|");

        }

        public void ShowInGameDisplay()
        {
            
        }
        
        public void ShowInGameHelp()
        {
            Console.WriteLine($"1 ----------- Starts New Game");
            Console.WriteLine($"2 --------------- Shows Possible Command Inputs");
            Console.WriteLine($"3 ----------Rolls the dice");
            Console.WriteLine($"4 ------Uses Extra Dice if it is available");
            Console.WriteLine($"5 -----Shows What Each Bonus Dice does when used");
            Console.WriteLine($"6 -----------Shows the effect of all the types of existing tiles");
            Console.WriteLine($"7-----------------Goes Back to Main Menu");
            Console.WriteLine($"8-----------------Exit Game");
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
            Console.WriteLine($"New Game ----------- Starts New Game");
            Console.WriteLine($"Help --------------- Shows " +
            "Possible Command Inputs");
            Console.WriteLine($"Throw Dice ----------Rolls the dice");
            Console.WriteLine($"Use Extra Dice-------Uses the " +
            "extra dice in case of having one");
            Console.WriteLine($"Bonus Dice info------Shows the " +
            "effects of using the Bonus Dices");
            Console.WriteLine($"Tile Info -----------Shows the " +
            "effect of all the types of existing tiles");
            Console.WriteLine($"Quit-----------------Exit To Main Menu");
            WaitingForInput(PlayerInput);
        }

        public string WaitingForInput(string playerInput)
        {
            Console.WriteLine("What do you want to do?");
            playerInput = Console.ReadLine();
            return playerInput;
        }

        public void ShowBoard(Board board)
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