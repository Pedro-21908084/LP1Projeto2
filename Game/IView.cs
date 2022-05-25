using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public interface IView
    {
        public string PlayerInput {get; set;}

        public void ShowMainMenu();

        public string WaitingForInput();

        public void ShowBoard();
    }
}