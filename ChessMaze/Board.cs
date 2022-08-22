using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    public class Board
    {
        //Size of the maze board - will determine the number of cells
        public int Size { get; set; }

        // this is a 2d array of cells (like a chess board)
        public Cell[,] mazeGrid { get; set; }

        // Constructor
        public Board (int size)
        {
            Size = size;

            mazeGrid = new Cell[Size, Size];

            // populate 2d array 
            //loops through to populate the Row value in Cell
            for (int x = 0; x < Size; x++)
            {
                //loops through to populate the Col value in Cell
                for (int y = 0; y < Size; y++)
                {
                    mazeGrid[x, y] = new Cell(x, y);
                }
            }
        }

        public void NextLegalMove (Cell currentCell, Part piece)
        {
            //reset board
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    mazeGrid[x, y].Occupied = false;
                    mazeGrid[x, y].IsLegal = false;
                }
            }

            // display legal moves for each piece
            switch(piece)
            {
                case (Part)'n':
                    mazeGrid[currentCell.Row + 2, currentCell.Col + 1].IsLegal = true;
                    mazeGrid[currentCell.Row + 2, currentCell.Col - 1].IsLegal = true;
                    mazeGrid[currentCell.Row + 1, currentCell.Col + 2].IsLegal = true;
                    mazeGrid[currentCell.Row + 1, currentCell.Col - 2].IsLegal = true;
                    mazeGrid[currentCell.Row - 1, currentCell.Col + 2].IsLegal = true;
                    mazeGrid[currentCell.Row - 1, currentCell.Col - 2].IsLegal = true;
                    mazeGrid[currentCell.Row - 2, currentCell.Col + 1].IsLegal = true;
                    mazeGrid[currentCell.Row - 2, currentCell.Col - 1].IsLegal = true;
                    break;

                case (Part)'b':
                    break;

                case (Part)'q':
                    break;

                case (Part)'k':
                    break;

                case (Part)'r':
                    break;
            }
            mazeGrid[currentCell.Row, currentCell.Col].Occupied = true;
        }
    }
}
