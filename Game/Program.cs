using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            TheView view = new TheView();

            Player player1 = new Player("🐍");
            Player player2 = new Player("🐍");
            Board model = new Board(player1,player2);

            view.ShowBoard(model, player1,player2);
        }
    }


}
