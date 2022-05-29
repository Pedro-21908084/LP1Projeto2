
using System;

namespace Game
{
    public class Board
    {
        public Tile[,] Map {get;private set;}
        public Player [] players;
        public string Turn{get; private set;}
        public Board( Player player1, Player player2)
        {
            players = new Player[]{player1, player2};
            
            GenerateMap();
        }

        /// <summary>
        /// Generates the map for play.
        /// </summary>
        private void GenerateMap()
        {
            Map = new Tile[5,5];

            for(int i = 0; i<5; i++)
            {
                for(int j = 0; j<5;j++)
                {
                    Map[i,j] = new Tile
                    (this, ArrayToBoard(i,j).ToString(), false);
                }
            }

            PlaceTile(new Boost(this), 0, 2, 1, 4);
            PlaceTile(new CheatDice(this), 1, 0, 4);
            PlaceTile(new Cobra(this), 1, 0, 2);
            PlaceTile(new ExtraDice(this), 1, 0, 4);
            PlaceTile(new Ladders(this), 2, 4, 1, 4);
            PlaceTile(new Snake(this), 2, 4, 0, 3);
            PlaceTile(new UTurn(this), 0, 2, 0, 3);

            ResetTurnMsg();
        }

        public void ResetTurnMsg() => Turn = "";

        public void AddToTurn(string s)=> Turn+= s;

        /// <summary>
        /// Moves a player int the right direction.
        /// </summary>
        /// <param name="direction">An array with 2 members, the first
        /// represents the movement in the vertical axis and the second 
        /// represents movement along the board</param>
        /// <param name="player">The player tha will be moved.</param>
        public void Move(int[] direction, Player player)
        {
            if(direction.Length > 1 && (direction[0] != 0 || direction[1] != 0))
            {
                if(direction[0] != 0)
                {
                    player.X -= direction[0];
                }

                if(direction[1] != 0)
                {
                    int playerPos = ArrayToBoard(player.X, player.Y);

                    playerPos += direction[1];

                    if(playerPos > 25)
                    {
                        int dif = playerPos - 25;
                        playerPos = 25 - dif;
                    }

                    int[] playerArr = BoardToArray(playerPos);

                    player.X = playerArr[0];
                    player.Y = playerArr[1];
                }
                
                //check for out of bounds
                player.X = (player.X > 4)? 4: (player.X < 0)? 0: player.X;
                player.Y = (player.Y > 4)? 4: (player.Y < 0)? 0: player.Y;

                int playerNum = (player.Icon == players[0].Icon)? 0 : 
                (player.Icon == players[1].Icon)? 1 : -1;

                if(playerNum != -1)
                {
                    if(Map[player.X, player.Y].IsSpecial)
                    {
                        Turn += $"\nPlayer {playerNum+1} moved to a special " + 
                        $"tile {Map[player.X, player.Y]} in " + 
                        $"{ArrayToBoard(player.X, player.Y)}, " + 
                        "because of tile effect:";
                    }else
                    {
                        Turn += $"\nPlayer {playerNum+1} moved to a normal " + 
                        $"tile in {ArrayToBoard(player.X, player.Y)}";
                    }
                }
                    
                //check overlap
                CheckForPlayerOverlap(player);

                Map[player.X, player.Y].Effect(player);
            }
        }

        /// <summary>
        /// Checks if player is on top of another player, moving the other if so.
        /// It also checks if moving the other will create stackoverflow, if so
        /// the effect of the tile where the other will go wont activate.
        /// </summary>
        /// <param name="player">The player who just moved.</param>
        private void CheckForPlayerOverlap(Player player)
        {
            int enemy = (players[0].Icon == player.Icon)? 1 : 0 ;
            //Console.WriteLine(player.Icon + ":" + players[(enemy == 0)?1:0].Icon);
            if(players[(enemy == 0)?1:0].Icon == player.Icon && 
                player.X == players[enemy].X && player.Y == players[enemy].Y &&
                !(player.X == 4 && player.Y == 0))
            {
                int playerNum = (enemy == 0)?1:0;
                Turn += $"\nPlayer {playerNum+1} landed on top of player {enemy+1}," + 
                " pushing him backwards";
                if(CheckStackOverFlowPlayers(player))
                {
                    int newPlayerPos = ArrayToBoard(player.X, player.Y);

                    newPlayerPos --;

                    int[] playerArr = BoardToArray(newPlayerPos);

                    players[enemy].X = playerArr[0];
                    players[enemy].Y = playerArr[1];
                }
                else
                    Move( new int[]{0,-1}, players[enemy]);
                
            }
        }

        /// <summary>
        /// Check if moving the player will create stackoverflow
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool CheckStackOverFlowPlayers(Player player)
        {
            bool result = false;

            Player testPlayer = new Player("T");
            testPlayer.X = player.X;
            testPlayer.Y = player.Y;

            Move( new int[]{0,-1}, testPlayer);

            if(testPlayer.X == player.X && testPlayer.Y == player.Y)
                result = true;

            return result;
        }

        /// <summary>
        /// Transform a position from an array to a position on the board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int ArrayToBoard(int x, int y) =>
        (x % 2 == 0) ? PosLine(x + 1) + y + 1 : PosLine(x) - y;

        /// <summary>
        /// Given a x value calculates the max value in that line.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int PosLine(int x) => 25 - x * 5;

        /// <summary>
        /// Transform a position from the board to a position on a array.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int[] BoardToArray(int pos)
        {
            int[] mat = new int[2];

            for (int i = 0; i < 5; i++)
            {
                if (pos > PosLine(i + 1))
                {
                    mat[0] = i;
                    if (PosLine(i) % 10 != 0)
                        mat[1] = 4 + pos - PosLine(i);
                    else
                        mat[1] = PosLine(i) - pos;
                    break;
                }
            }
            return mat;
        }

        /// <summary>
        /// Gets a random  from 1 to 6.
        /// </summary>
        /// <returns></returns>
        public int ThrowDice()
        {
            // Initialization of a new local instance of the class Random 
            Random dice = new Random();
            // Number randomly chosen between a min (1) and a max (6/non-inclusive 7)  
            int diceNumber = dice.Next(1, 7);
            // returns the value of diceNumber
            return diceNumber;
        }

        /// <summary>
        /// Places a tile "tile" a number of times between min and max, between 
        /// the minlines and maxlines
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="minLine"></param>
        /// <param name="maxLine"></param>
        private void PlaceTile
        (Tile tile, int min, int max, int minLine, int maxLine)
        {
            Random rand = new Random();
            //generates a random number betwen given min and max values
            int quantity = rand.Next(min, max + 1);
            //call SpecialTiles with the value generated
            PlaceTile(tile, quantity, minLine, maxLine);
        }

        /// <summary>
        /// Places a tile "tile" "quantity" times, between the minlines and 
        /// maxlines
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="quantity"></param>
        /// <param name="minLine"></param>
        /// <param name="maxLine"></param>
        private void PlaceTile(Tile tile, int quantity, int minLine, int maxLine)
        {
            int[] pos;

            for(int i = 0; i < quantity; i++)
            {
                pos = GenerateRandomPos(tile, minLine, maxLine);

                Map[pos[0], pos[1]] = tile;
            }
        }

        /// <summary>
        /// Generates a random position for tile between min and max lines, 
        /// checking if it will cause stackoverflow, if it is in the start or
        /// fishlines , generating a new position if so.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int[] GenerateRandomPos(Tile tile, int min, int max)
        {
            Random pos = new Random();
            //generate a random position
            int x, y;
            do
            {
                x = pos.Next(min, max+1);
                y = pos.Next(0, 5);
                //check if position as another special or is starting/finishing
                // lines
            } while ((x == 0 && y == 4) || (x == 4 && y == 0) || 
                Map[x, y].IsSpecial || CheckForStackOverFlow(tile, x, y));
                //CheckForStackOverFlow(tile, x, y));

            int[] position = { x, y };
            return position;
        }

        private bool CheckForStackOverFlow(Tile tile, int x, int y)
        {
            bool result = false;

            Player testPlayer = new Player("T");
            testPlayer.X = x;
            testPlayer.Y = y;

            tile.Effect(testPlayer);

            if(testPlayer.X == x && testPlayer.Y == y && 
                !testPlayer.CheatDice && !testPlayer.ExtraDice)
                result = true;

            return result;
        }

        public int CheckWinner()
        {
            int winner = 0;

            if(players[0].X == 0 && players[0].Y == 4)
                winner = 1;
            else if(players[1].X == 0 && players[1].Y == 4)
                winner = 2;

            return winner;
        }
    }
}