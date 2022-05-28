using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public interface IView
    {
        //Variables/Properties
        public string PlayerInput {get; set;}

        //Methods
        public void ShowMainMenu();
        
        public void ShowInGameDisplay(Board board, Player player1, Player player2);

        public void ShowInGameHelp();

        public void ShowBonusDiceInfo();

        public void ShowTileInfo();

        public string WaitingForInput(string playerInput);

        public void ShowBoard(Board board, Player player1, Player player2);

        public void ShowPlayerMoves();
    }
}