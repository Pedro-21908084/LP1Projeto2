using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class TheView:IView
    {
        public string PlayerInput {get; set;}

        
        public void ShowMainMenu()
        {
            Console.WriteLine("             ______________________________________________________");
            Console.WriteLine("            |Welcome To Snakes and Ladders: Command Console Edition|");
            Console.WriteLine(" ___________|______________________________________________________|___________");
            Console.WriteLine("| 1----------------------------------------------------------------Runs the game|");
            Console.WriteLine("| 2--------------------------------------------------------------Loads Save Game|");
            Console.WriteLine("| 0-------------------------------------------------------------------Exits Game|");
            Console.WriteLine("|_______________________________________________________________________________|");


        }
        
        public void ShowInGameDisplay(Board board)
        {
            Console.WriteLine("Game Begun");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("These are the possible inputs and what they do:");
            Console.WriteLine(" ");
            Console.WriteLine($"1 -----------------------------------------------Starts New Game");
            Console.WriteLine($"2 ------------------------------------Help(Show Possible Inputs)");
            Console.WriteLine($"3 ------------------------------------------------Rolls the dice");
            Console.WriteLine($"4 ----------------------------Uses Extra Dice if it is available");
            Console.WriteLine($"5 ---------------------Shows What Each Bonus Dice does when used");
            Console.WriteLine($"6 -----------Shows the effect of all the types of existing tiles");
            Console.WriteLine($"7-------------------------------------Save and Exit to Main Menu");
            Console.WriteLine($"0------------------------------------------------------Exit Game");
            Console.WriteLine("");
        }
        

        public void ShowInGameHelp()
        {
            Console.WriteLine($"1 -----------------------------------------------Starts New Game");
            Console.WriteLine($"2 ------------------------------------Help(Show Possible Inputs)");
            Console.WriteLine($"3 ------------------------------------------------Rolls the dice");
            Console.WriteLine($"4 ----------------------------Uses Extra Dice if it is available");
            Console.WriteLine($"5 ---------------------Shows What Each Bonus Dice does when used");
            Console.WriteLine($"6 -----------Shows the effect of all the types of existing tiles");
            Console.WriteLine($"7-------------------------------------Save and Exit to Main Menu");
            Console.WriteLine($"0------------------------------------------------------Exit Game");
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
        }
        

        public void ShowTileInfo()
        {
            Console.WriteLine($"Normal Tiles do not affect the " + 
            "player position. They are represented by numbers");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine($"Snake Tiles make the player go " + 
            "vertically down 1 tile. They are represented by " +
            " this symbol:🐍");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine($"Ladder Tiles make the player go " +
            "vertically up 1 tile. They are represented by " +
            "numbers by this symbol:冃");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine($"Cobra Tiles make the player go " +
            "back to the first spot of the board. They are " +
            "represented by this symbol:🟥");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine($"Boost Tiles make the player go " +
            "forward 2 tiles. They are represented by this " +
            "symbol:  🚀 ");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine($"U-turn Tiles make the player go " +
            "back 2 tiles. They are represented by this symbol:  ↺ ");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine($"Extra Die Tiles grant the player" +
            " an extra dice(If the player already has 1 " + 
            "extra dice no more will be granted). They are " +
            "represented by this symbol:➕");
            Console.WriteLine("---------------------------------" +
            "-----------------------------------------------");
            Console.WriteLine($"Cheat Die Tiles grant the player" +
            " the option to choose a number and move a number" +
            " of tiles using that number. They are " + 
            "represented by this symbol:🎲");
        }
        
        public void WaitingForInput()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("What do you want to do?");
            PlayerInput = Console.ReadLine();
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
                    if(i== 4 && j == 0 && board.players[0].X == 4 && board.players[0].Y == 0 && 
                    board.players[1].X == 4 && board.players[1].Y == 0)
                    {
                        Console.Write(" 👫 |");
                    }
                    else if(board.players[0].X == i && board.players[0].Y == j)
                    {
                        Console.Write($" {board.players[0]} |");
                    }
                    else if(board.players[1].X == i && board.players[1].Y == j)
                    {
                        Console.Write($" {board.players[1]} |");
                    }
                    else 
                    {
                        
                        if(board.Map[i,j].ToString().Length == 1 && ( board.Map[i,j].Icon == "↺" || !board.Map[i,j].IsSpecial))
                        {
                            Console.Write(" ");
                        }
                        Console.Write($" {board.Map[i,j]} |");
                    }
                    
                }
                Console.WriteLine("\n|____||____||____||____||____|");
            }
        }
        

        public void ShowPlayerMoves(Board board)
        {
            Console.WriteLine(board.Turn);
        }
        

        public void ShowDiceRoll(int diceRollNumber)
        {
            Console.WriteLine($"The dice rolled a : {diceRollNumber}");
        }
        

        public void ShowExtraDiceResult(int sumOfDicesRoll)
        {
            Console.WriteLine($"The sum of the 2 Dice was: {sumOfDicesRoll}");
        }
        

        public void ShowExtraDiceError()
        {
            Console.WriteLine($"You don't have an Extra Dice to use");    
        }
        

        public string AskCheatDiceQuestion()
        {
            Console.WriteLine("Do you want to use your Cheat Dice to roll a " +
            "number of your choosing?(1 - Yes/2 - No)");
            string answer = Console.ReadLine();
            return answer;
        }
        

        public int AskCheatDiceRoll()
        {
            Console.WriteLine("What Number you want to roll?(1-6)");
            int numberChosen = int.Parse(Console.ReadLine());
            return numberChosen;
        }

        
        public void ShowOutOfBoundsMessage(int numberOfTilesOver25)
        {
            Console.WriteLine($"You went {numberOfTilesOver25} over the finish line");
        }
        
        public void ShowWinMessage(int playerNumber)
        {
            Console.WriteLine($"Player{playerNumber} won the match");
        }

        public void ShowPlayerUI(Board board, int playerNumber)
        {
            Console.WriteLine($"It's Player {playerNumber} turn");
            Console.WriteLine($"Do you have Extra Dice? {board.players[playerNumber - 1].ExtraDice}");
            Console.WriteLine($"Do you have Cheat Dice? {board.players[playerNumber - 1].CheatDice}");   
        }
        
        public void ErrorMessage()
        {
            Console.WriteLine("Invalid Input");
        }
        
        public void LoadErrorMessage()
        {
            Console.WriteLine("File doesn't exist");
        }

        
        

    }
}