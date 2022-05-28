
namespace Game
{
    public class Board
    {
        private Tile[,] map;
        private Player [] players;

        public Board( Player player1, Player player2)
        {
            map = GenerateMap();
            players = new Player[]{player1, player2};
        }

        private Tile[,] GenerateMap()
        {
            Tile[,] temp = new Tile[5,5];

            for(int i = 0; i<5; i++)
            {
                for(int j = 0; j<5;j++)
                {
                    temp[i,j] = new Tile(this, ArrayToBoard(i,j));
                }
            }

            temp[0,0] = new Boost();
            temp[0,1] = new CheatDice();
            temp[0,2] = new Cobra();
            temp[1,0] = new ExtraDice();
            temp[1,1] = new Ladders();
            temp[1,2] = new Snake();
            temp[2,0] = new UTurn();

            return temp;
            
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

                map[player.X, player.Y].Effect(player);
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
    }
}