using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            Game game = new Game();
            while (true)
            {
                game.G_playGame();
                Console.WriteLine("\nDo you want to play again? if yes - type anything, else type 'no': ");
                if (Console.ReadLine().ToLower().Equals("no")) { Console.WriteLine("\nFarewell dear player!\n");  break; }
                game.P1.Board = new Board(game.P1.P_getLevel());
            }
        }
    }
}
