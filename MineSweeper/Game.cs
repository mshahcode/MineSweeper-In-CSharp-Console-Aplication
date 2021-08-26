using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Game
    {
        private Player p1;
        public Player P1 { get => p1; set => p1 = value; }


        public Game()
        {
            this.p1 = new Player();
        }
        
        public void G_playGame()
        {
            while(!G_isGameOver() && !G_win())
            {
                p1.P_put();
            }
            G_congratulate();
        }

        public bool G_isGameOver()
        {
            foreach(var cell in p1.Board.Cells)
            {
                if(cell.Letter=='*' && cell.IsSelected)
                {
                    return true;
                }
            }
            return false;
        }

        public bool G_win() {

            foreach (var cell in p1.Board.Cells)
            {
                if (cell.Letter != '*' && !cell.IsSelected)
                {
                    return false;
                }
            }
            return true;

        }

        public void G_congratulate()
        {
            if (G_win())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dear {0}, congratilations, you win!",p1.Name);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dear {0}, sorry, you lost!",p1.Name);
            }
            Console.ResetColor();
        }
    }
}
