using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MineSweeper
{
    class Board
    {
        private Cell[,] cells;


        public Cell[,] Cells { get => cells; set => cells = value; }

        public Board(int size)
        {
            this.cells = new Cell[size, size];
            B_initialize();
        }

        public void B_initialize()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    this.cells[i, j] = new Cell(i, j);
                }
            }
        }

        public void B_show(bool mode = true)
        {
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                Console.Write(i + " ");
                if (i < 10) { Console.Write(" "); }
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (mode)
                    {
                        if (cells[i, j].Letter == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\u25cf");
                        }
                        else if(cells[i, j].Letter == '-')
                        {
                            Console.Write(cells[i, j].Letter);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(cells[i, j].Letter);

                        }
                    }
                    else
                    {
                        if (!cells[i, j].IsSelected)
                        {
                            Console.Write("\u25a0");
                        }
                        else
                        {
                            if(cells[i,j].Letter == '*')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\u25cf");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(cells[i, j].Letter);
                            }
                        }
                    }
                    Console.ResetColor();
                    if (j < 10) { Console.Write(" "); }
                    else { Console.Write("  "); }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool B_belong(int row, int col)
        {
            if (row >= 0 && row < cells.GetLength(0) && col >= 0 && col < cells.GetLength(0))
            {
                return true;
            }
            return false;
        }

        public Cell[] B_checkNeighbours(int x, int y)
        {
            LinkedList<Cell> neighbours = new LinkedList<Cell>();
            if (B_belong(x - 1, y))
            {
                neighbours.AddLast(this.cells[x - 1, y]);
            }
            if (B_belong(x + 1, y))
            {
                neighbours.AddLast(this.cells[x + 1, y]);
            }
            if (B_belong(x, y + 1))
            {
                neighbours.AddLast(this.cells[x, y + 1]);
            }
            if (B_belong(x, y - 1))
            {
                neighbours.AddLast(this.cells[x, y - 1]);
            }
            if (B_belong(x - 1, y - 1))
            {
                neighbours.AddLast(this.cells[x - 1, y - 1]);
            }
            if (B_belong(x - 1, y + 1))
            {
                neighbours.AddLast(this.cells[x - 1, y + 1]);
            }
            if (B_belong(x + 1, y + 1))
            {
                neighbours.AddLast(this.cells[x + 1, y + 1]);
            }
            if (B_belong(x + 1, y - 1))
            {
                neighbours.AddLast(this.cells[x + 1, y - 1]);
            }
            return neighbours.ToArray();
        }

        public void B_fillMines()
        {
            Random rand = new Random();
            for (int i = 0; i < cells.GetLength(0); i++) {
                while (true)
                {
                    int X = rand.Next(cells.GetLength(0));
                    int Y = rand.Next(cells.GetLength(0));

                    if (cells[X, Y].Letter == '-')
                    {
                        cells[X, Y].Letter = '*';
                        break;
                    }
                }

            }
        }

        public void B_fillNumbers()
        {
            foreach(Cell cell in cells)
            {
                if (cell.Letter != '*')
                {
                    int count = 0;
                    foreach (Cell cellneighbour in B_checkNeighbours(cell.Row, cell.Col))
                    {
                        if (cellneighbour.Letter == '*')
                        {
                            count++;
                        }
                    }
                    cell.Letter = char.Parse(count.ToString());
                }
            }
        }

        public void B_openEmpty(int x,int y)
        {
            cells[x, y].IsSelected = true;
            Cell[] nighbours = B_checkNeighbours(x, y);
            foreach(Cell cellneighbour in nighbours)
            {
                if (cellneighbour.Letter == '0' && !cellneighbour.IsSelected)
                {
                    B_openEmpty(cellneighbour.Row, cellneighbour.Col);
                }
                else
                {
                    this.cells[cellneighbour.Row, cellneighbour.Col].IsSelected = true;
                }
            }
        }

        public bool B_canSelect(int x,int y)
        {
            if (B_belong(x, y))
            {
                if(!cells[x, y].IsSelected)
                {
                    return true;
                }
            }
            return false;   
        }

        public void B_place(int x,int y)
        {
            if(cells[x,y].Letter == '0')
            {
                B_openEmpty(x, y);
            }
            else
            {
                cells[x, y].IsSelected = true;
            }
        }
    }
}
