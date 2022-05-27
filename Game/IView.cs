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
        
        public void ShowInGameDisplay();

        public void ShowInGameHelp();

        public void ShowBonusDiceInfo();

        public void ShowTileInfo();

        public string WaitingForInput(string playerInput);

        public void ShowBoard();

        public void ShowPlayerMoves();
    }
}