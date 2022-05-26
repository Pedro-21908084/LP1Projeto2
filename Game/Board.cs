using System.CodeDom.Compiler;
using System.Globalization;
using System.Reflection;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    public class Board
    {
        private Tile[,] map;

        public Board()
        {
            map = GenerateMap(); 
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

            return temp;
            
        }

        public void Move(int[] direction, Player player)
        {
            if(direction.Length > 1)
            {
                
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