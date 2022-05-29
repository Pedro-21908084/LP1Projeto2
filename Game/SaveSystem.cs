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

        /// <summary>
        /// Constructor for class SaveSystem
        /// </summary>
        /// <param name="name">Name of the save file</param>
        public SaveSystem(string name)
        {
            path = name + ".txt";
        }

        /// <summary>
        /// Deletes the current save file
        /// </summary>
        public void DeleteSaveFile()
        {
            File.Delete(path);
        }

        /// <summary>
        /// Saves contents of a given board (Map[,] and players[]) to a file 
        /// </summary>
        /// <param name="board"></param>
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
            player1 = Player2String(board.players[0]);
            save.Add(player1);
            player2 = Player2String(board.players[1]);
            save.Add(player2);

            File.WriteAllLines(path, save);
        }

        /// <summary>
        /// Converts a given player to a string, separating its variables with
        /// "/"
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Returns a string with the contents of player</returns>
        private string Player2String(Player player)
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

        /// <summary>
        /// Tries to load a file to a given board
        /// </summary>
        /// <param name="board"></param>
        /// <returns>Returns true if it could load, and false otherwise</returns>
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

        /// <summary>
        /// Converts a given array of strings to a variable player
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Returns a player with the variables values passed in the 
        /// strings</returns>
        private Player String2Player(string[] s)
        {
            Player player = new Player(s[4]);

            player.X = int.Parse(s[0]);
            player.Y = int.Parse(s[1]);
            player.CheatDice = bool.Parse(s[2]);
            player.ExtraDice = bool.Parse(s[3]);

            return player;
        }

        /// <summary>
        /// Converts a given string to a variable Tile
        /// </summary>
        /// <param name="s"></param>
        /// <param name="board"></param>
        /// <param name="index"></param>
        /// <returns>Returns a variable Tile stored in the string s</returns>
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