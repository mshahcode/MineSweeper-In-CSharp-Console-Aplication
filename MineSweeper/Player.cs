using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Player
    {
        private Board board;
        private string name;

        public Board Board { get => board; set => board = value; }
        public string Name { get => name; set => name = value; }

        public Player()
        {
            Console.Write("\nHello, please enter your name: ");
            this.name = Console.ReadLine();
            this.board = new Board(P_getLevel());
            this.board.B_fillMines();
            this.board.B_fillNumbers();
        }

        public int P_getLevel()
        {
            int size = 0;
            while (true)
            {
                Console.Write("\nDear {0}, select one of the levels (simple - 0),(medium = 1),(hard - 2): ", this.name);
                string option = Console.ReadLine();
                if (!Int32.TryParse(option, out int optionAsInt))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nDear {0}, please, type correct number (0 or 1 or 2)\n", this.name);
                    Console.ResetColor();
                    continue;
                }
                if (optionAsInt == 0) {
                    size = 5;
                    break;
                }
                if (optionAsInt == 1) {
                    size = 10;
                    break;
                }
                if (optionAsInt == 2) {
                    size = 15;
                    break;
                }
            }
            return size;
        }

        public void P_put()
        {
            int[] output = new int[3];
            int x, y;
            string input;
            while (true)
            {
                this.board.B_show(false);
                Console.WriteLine("Dear {0}, please select coordinates on the board", this.name);
                Console.Write("In this order: row col: ");
                input = Console.ReadLine();
                output = new int[2];
                if (ValidInput(input, output))
                {
                    x = output[0];
                    y = output[1];
                    
                }
                else { continue; }
                if (board.B_canSelect(x, y))
                {
                    board.B_place(x, y);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou can't place here!\n");
                    Console.ResetColor();
                }

            }
            this.board.B_show(false);

        }

        public bool ValidInput(string input, int[] output)
        {
            string[] inputs = input.Split(' ');
            if (inputs.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nMore or less than 2 inputs! Only 2 inputs must be written\n");
                Console.ResetColor();
                return false;
            }
            foreach (string str in inputs)
            {
                if (!int.TryParse(str, out int number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease enter valid inputs(Only integers, and only 2 numbers\n!");
                    Console.ResetColor();
                    return false;
                }
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                output[i] = int.Parse(inputs[i]);
            }
            return true;
        }

    }
}
