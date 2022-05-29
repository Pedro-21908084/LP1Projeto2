using System;
using System.Text;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TheView view = new TheView();
            Player player1 = new Player("🧑");
            Player player2 = new Player("👩");
            Board model = new Board(player1,player2);
            SaveSystem saveSystem = new SaveSystem("Snakes&Ladders");
            Controller controller = new Controller(view, model, saveSystem);
            controller.RunGame(view);

            
        }

    }


}
