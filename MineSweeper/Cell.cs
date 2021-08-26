using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Cell
    {
        private int row;
        private int col;
        private bool isSelected;
        private char letter;

        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public bool IsSelected{ get => isSelected; set => isSelected = value; }
        public char Letter { get => letter; set => letter = value; }

        public Cell(int row,int col,char letter)
        {
            this.row = row;
            this.col = col;
            this.letter = letter;
            this.isSelected = false;
        }

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.letter = '-';
            this.isSelected = false;
        }



    }
}
