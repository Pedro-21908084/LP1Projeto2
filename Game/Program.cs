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

            view.ShowBoard(model, player1,player2);

            int dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player1);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);
            dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player2);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);

            dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player1);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);
            dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player2);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);

            dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player1);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);
            dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player2);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);

            dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player1);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);
            dice = model.ThrowDice();
            model.Move(new int[]{0, dice}, player2);
            Console.WriteLine($"You rolled a :{dice}");
            Console.WriteLine(model.Turn);
            model.ResetTurnMsg();
            view.ShowBoard(model, player1,player2);
        }

    }


}
