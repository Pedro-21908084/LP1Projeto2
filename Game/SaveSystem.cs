using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class SaveSystem
    {
        private string path;

        public SaveSystem(string name)
        {
            path = name + ".txt";
        }
        
        public void DeleteSaveFile()
        {
            File.Delete(path);
        }

        public void Save(Board board){
            string map = "";
            string player1 = "";
            string player2 = "";
            List<string> save = new List<string>();
            for (int i = 0; i < 5 ;i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    map += board.Map[i,j];
                    if(j != 4 || i != 4)
                        map += "/";
                }
            }

            save.Add(map);
            player1 = ConvertPlayerToString(board.players[0]);
            save.Add(player1);
            player2 = ConvertPlayerToString(board.players[1]);
            save.Add(player2);

            File.WriteAllLines(path, save);
        }

        private string ConvertPlayerToString(Player player)
        {
            string playerString = "";

            playerString += player.X;
            playerString += "/";
            playerString += player.Y;
            playerString += "/";
            playerString += player.CheatDice;
            playerString += "/";
            playerString += player.ExtraDice;
            playerString += "/";
            playerString += player.Icon;

            return playerString;
        }
    }
}