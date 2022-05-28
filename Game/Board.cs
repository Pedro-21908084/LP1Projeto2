
using System;

namespace Game
{
    public class Board
    {
        public Tile[,] Map {get;private set;}
        private Player [] players;

        public Board( Player player1, Player player2)
        {
            GenerateMap();
            players = new Player[]{player1, player2};
        }

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
        }

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

                    int[] playerArr = BoardToArray(playerPos);

                    player.X = playerArr[0];
                    player.Y = playerArr[1];
                }
                
                //check for out of bounds
                player.X = (player.X > 4)? 4: (player.X < 0)? 0: player.X;
                player.Y = (player.Y > 4)? 4: (player.Y < 0)? 0: player.Y;

                //check overlap

                Map[player.X, player.Y].Effect(player);
            }
        }

        private int ArrayToBoard(int x, int y) =>
        (x % 2 == 0) ? PosLine(x + 1) + y + 1 : PosLine(x) - y;

        private int PosLine(int x) => 25 - x * 5;

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

        public int ThrowDice()
        {
            // Initialization of a new local instance of the class Random 
            Random dice = new Random();
            // Number randomly chosen between a min (1) and a max (6/non-inclusive 7)  
            int diceNumber = dice.Next(1, 7);
            // returns the value of diceNumber
            return diceNumber;
        }

        private void PlaceTile
        (Tile tile, int min, int max, int minLine, int maxLine)
        {
            Random rand = new Random();
            //generates a random number betwen given min and max values
            int quantity = rand.Next(min, max + 1);
            //call SpecialTiles with the value generated
            PlaceTile(tile, quantity, minLine, maxLine);
        }

        private void PlaceTile(Tile tile, int quantity, int minLine, int maxLine)
        {
            int[] pos;

            for(int i = 0; i < quantity; i++)
            {
                pos = GenerateRandomPos(tile, minLine, maxLine);

                Map[pos[0], pos[1]] = tile;
            }
        }

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
    }
}