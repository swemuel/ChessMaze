using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    public class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Occupied { get; set; }
        public bool IsLegal { get; set; }
        public Part Piece { get; set; }
        
        public bool playerCell;

        public Cell(int x, int y)
        {
            Row = x;
            Col = y;
        }

        //Checks the cell is on the board
        public bool isValid()
        {
            if ((this.Col >= 0 & this.Col < 8) & (this.Row >= 0 & this.Row < 8))
            {
                return true;
            } 
            else
            {
                this.IsLegal = false;
                return false;
            }
        }

    }
}
