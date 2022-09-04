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
            // if  mazeGrid[nextRow, nextCol] isValid {check if the knight can move there}
            // display legal moves for each piece
            switch (piece)
            {
                case (Part)'n':

                    //var targetCell = new Cell { Row = currentCell.Row + 2, Col = currentCell.Col - 1 };
                    //if targetCell.isValid()

                    int[,] targetPositions = new int[,]
                    {
                        {  2, -1 },
                        {  2,  1 },
                        {  1,  2 },
                        {  1, -2 },
                        { -1,  2 },
                        { -1, -2 },
                        { -2,  1 },
                        { -2, -1 }
                    };

               
                    for (var i = 0; i < targetPositions.GetLength(0); ++i)
                    {
                        if ((currentCell.Row + targetPositions[i, 0] >= 0) & (currentCell.Row + targetPositions[i, 0] < Size) 
                            & (currentCell.Col + targetPositions[i, 1] >= 0) & (currentCell.Col + targetPositions[i, 1] < Size))
                        {
                            mazeGrid[currentCell.Row + targetPositions[i, 0], currentCell.Col + targetPositions[i, 1]].IsLegal = true;
                        }            
                    }
      
                    break;

                case (Part)'b':
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row + i >= 0) & (currentCell.Row + i < Size)
                            & (currentCell.Col + i >= 0) & (currentCell.Col + i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row + i, currentCell.Col + i].Occupied)
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col + i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col + i].IsLegal = true;
                            }
                        }
                    }
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row - i >= 0) & (currentCell.Row - i < Size)
                            & (currentCell.Col - i >= 0) & (currentCell.Col - i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row - i, currentCell.Col - i].Occupied)
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col - i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col - i].IsLegal = true;
                            }
                        }
                    }
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row + i >= 0) & (currentCell.Row + i < Size)
                            & (currentCell.Col - i >= 0) & (currentCell.Col - i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row + i, currentCell.Col - i].Occupied)
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col - i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col - i].IsLegal = true;
                            }
                        }
                    }
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row - i >= 0) & (currentCell.Row - i < Size)
                            & (currentCell.Col + i >= 0) & (currentCell.Col + i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row - i, currentCell.Col + i].Occupied)
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col + i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col + i].IsLegal = true;
                            }
                        }
                    }
                    break;

                case (Part)'q':

                    // Diagonal movement
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row + i >= 0) & (currentCell.Row + i < Size)
                            & (currentCell.Col + i >= 0) & (currentCell.Col + i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row + i, currentCell.Col + i].Occupied)
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col + i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col + i].IsLegal = true;
                            }
                        }
                    }
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row - i >= 0) & (currentCell.Row - i < Size)
                            & (currentCell.Col - i >= 0) & (currentCell.Col - i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row - i, currentCell.Col - i].Occupied)
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col - i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col - i].IsLegal = true;
                            }
                        }
                    }
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row + i >= 0) & (currentCell.Row + i < Size)
                            & (currentCell.Col - i >= 0) & (currentCell.Col - i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row + i, currentCell.Col - i].Occupied)
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col - i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row + i, currentCell.Col - i].IsLegal = true;
                            }
                        }
                    }
                    for (var i = 0; i < Size; ++i)
                    {
                        if ((currentCell.Row - i >= 0) & (currentCell.Row - i < Size)
                            & (currentCell.Col + i >= 0) & (currentCell.Col + i < Size))
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row - i, currentCell.Col + i].Occupied)
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col + i].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row - i, currentCell.Col + i].IsLegal = true;
                            }
                        }
                    }

                    // Vertical and horizontal movement
                    // left and down
                    for (int i = 0; i < Size - currentCell.Row; i++)
                    {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (mazeGrid[currentCell.Row + i, currentCell.Col].Occupied)
                        {
                            mazeGrid[currentCell.Row + i, currentCell.Col].IsLegal = true;
                            break;
                        }
                        else
                        {
                            mazeGrid[currentCell.Row + i, currentCell.Col].IsLegal = true;
                        }

                        for (int j = 0; j < currentCell.Col; j++)
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row, currentCell.Col - j - 1].Occupied)
                            {
                                mazeGrid[currentCell.Row, currentCell.Col - j - 1].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row, currentCell.Col - j - 1].IsLegal = true;
                            }
                        }
                    }
                    //  right and up
                    for (int i = 0; i < currentCell.Row; i++)
                    {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (mazeGrid[currentCell.Row - i - 1, currentCell.Col].Occupied)
                        {
                            mazeGrid[currentCell.Row - i - 1, currentCell.Col].IsLegal = true;
                            break;
                        }
                        else
                        {
                            mazeGrid[currentCell.Row - i - 1, currentCell.Col].IsLegal = true;
                        }

                        for (int j = 0; j < Size - currentCell.Col; j++)
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row, currentCell.Col + j].Occupied)
                            {
                                mazeGrid[currentCell.Row, currentCell.Col + j].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row, currentCell.Col + j].IsLegal = true;
                            }
                        }
                    }
                    break;

                case (Part)'k':
                    targetPositions = new int[,]
                    {
                        {  1, -1 },
                        {  1,  1 },
                        {  1,  0 },
                        { -1, -1 },
                        { -1,  1 },
                        { -1,  0 },
                        {  0,  1 },
                        {  0, -1 }
                    };


                    for (var i = 0; i < targetPositions.GetLength(0); ++i)
                    {
                        if ((currentCell.Row + targetPositions[i, 0] >= 0) & (currentCell.Row + targetPositions[i, 0] < Size)
                            & (currentCell.Col + targetPositions[i, 1] >= 0) & (currentCell.Col + targetPositions[i, 1] < Size))
                        {
                            mazeGrid[currentCell.Row + targetPositions[i, 0], currentCell.Col + targetPositions[i, 1]].IsLegal = true;
                        }
                    }
                    break;

                case (Part)'r':
                    // left and down
                    for (int i = 0; i < Size - currentCell.Row; i++)
                    {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (mazeGrid[currentCell.Row + i, currentCell.Col].Occupied)
                        {
                            mazeGrid[currentCell.Row + i, currentCell.Col].IsLegal = true;
                            break;
                        }
                        else
                        {
                            mazeGrid[currentCell.Row + i, currentCell.Col].IsLegal = true;
                        }

                        for (int j = 0; j < currentCell.Col; j++)
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row, currentCell.Col - j - 1].Occupied)
                            {
                                mazeGrid[currentCell.Row, currentCell.Col - j - 1].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row, currentCell.Col - j - 1].IsLegal = true;
                            }
                        }
                    }
                    //  right and up
                    for (int i = 0; i < currentCell.Row; i++)
                     {
                        // check if next cell is occupied - if so then set as legal and exit the for loop
                        if (mazeGrid[currentCell.Row - i - 1, currentCell.Col].Occupied)
                        {
                            mazeGrid[currentCell.Row - i - 1, currentCell.Col].IsLegal = true;
                            break;
                        }
                        else
                        {
                            mazeGrid[currentCell.Row - i - 1, currentCell.Col].IsLegal = true;
                        }

                        for (int j = 0; j < Size - currentCell.Col; j++)
                        {
                            // check if next cell is occupied - if so then set as legal and exit the for loop
                            if (mazeGrid[currentCell.Row, currentCell.Col + j].Occupied)
                            {
                                mazeGrid[currentCell.Row, currentCell.Col + j].IsLegal = true;
                                break;
                            }
                            else
                            {
                                mazeGrid[currentCell.Row, currentCell.Col + j].IsLegal = true;
                            }
                        }
                    }
                    break;
            }
            mazeGrid[currentCell.Row, currentCell.Col].playerCell = true;
        }

        public Cell SetStartGame(int currentRow, int currentCol)
        {
            //reset Board
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    mazeGrid[x, y].Occupied = false;
                    mazeGrid[x, y].IsLegal = false;
                }
            }

            Cell currentCell = this.mazeGrid[currentRow, currentCol];

            // get x and y co-ords and check they're are within the board
            if (currentCell.isValid())
            {
                currentCell.playerCell = true;
                return currentCell;
            } 
            else
            {
                Console.WriteLine("Col and Row number must be between 0 - 7");
                return currentCell;
            }
        }

        public Cell SetOccupiedPiece(int occupiedRow, int occupiedCol, Part piece)
        {
            Cell occupiedCell = this.mazeGrid[occupiedRow, occupiedCol];
            // get x and y co-ords and check they're are within the board
            if (occupiedCell.isValid())
            {
                occupiedCell.Piece = piece;
                occupiedCell.Occupied = true;
                return occupiedCell;
            }
            else
            {
                Console.WriteLine("Col and Row number must be between 0 - 7");
                return occupiedCell;
            }
        }
    }
}
