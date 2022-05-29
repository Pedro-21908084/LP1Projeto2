using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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

        public bool Load(Board board)
        {
            if(File.Exists(path))
            {
                string[] save = File.ReadAllLines(path);

                string[] map = save[0].Split("/");
                string[] player1 = save[1].Split("/");
                string[] player2 = save[2].Split("/");

                for (int i = 0; i < 5 ;i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        board.Map[i,j] = String2Tile(map[i*5 +j], board, board.ArrayToBoard(i,j));
                    }
                }

                board.players[0] = String2Player(player1);
                board.players[1] = String2Player(player2);

                return true;
            }

            return false;
        }

        private Player String2Player(string[] s)
        {
            Player player = new Player(s[4]);

            player.X = int.Parse(s[0]);
            player.Y = int.Parse(s[1]);
            player.CheatDice = bool.Parse(s[2]);
            player.ExtraDice = bool.Parse(s[3]);

            return player;
        }

        private Tile String2Tile(string s, Board board, int index)
        {
            Tile tile;
            switch(s)
            {
                case "🚀":
                    tile = new Boost(board);
                    break;
                case "🎲":
                    tile = new CheatDice(board);
                    break;
                case "🟥":
                    tile = new Cobra(board);
                    break;
                case "➕":
                    tile = new ExtraDice(board);
                    break;
                case "冃":
                    tile = new Ladders(board);
                    break;
                case "🐍":
                    tile = new Snake(board);
                    break;
                case "↺":
                    tile = new UTurn(board);
                    break;
                default:
                    tile = new Tile( board, index.ToString(), false);
                    break;
            }

            return tile;
        }
    }
}