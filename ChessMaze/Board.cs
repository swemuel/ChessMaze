﻿using System;
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

        public void NextLegalMove (int nextRow, int nextCol, Cell currentCell, Part piece)
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
            // if  mazeGrid[nextRow, nextCol] isValid {check if the knight can move there}
            // display legal moves for each piece
            switch (piece)
            {
                case (Part)'n':
                    if(mazeGrid[nextRow, nextCol].isValid())
                    {

                    }
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

        public Cell SetCurrentCell(int currentRow, int currentCol)
        {
            Cell currentCell = this.mazeGrid[currentRow, currentCol];
            // get x and y co-ords and check they're are within the board
            if (currentCell.isValid())
            {
                return currentCell;
            } 
            else
            {
                Console.WriteLine("Col and Row number must be between 0 - 7");
                return currentCell;
            }
            
        }
    }
}
