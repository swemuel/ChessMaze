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

        public int MoveCount;
        // this is a 2d array of cells (like a chess board)
        public Cell[,] mazeGrid { get; set; }
        public Cell playerCell { get; set; }
        public Cell prevCell { get; set; }
        public Cell finalCell { get; set; }

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

        protected void RookMovement(Cell currentCell)
        {
            // DOWN
            for (int i = 1; i <= Size - currentCell.Row; i++)
            {
                // check if Down movement is valid
                if (currentCell.Row + i <= Size - 1)
                {
                    // check if next cell is occupied
                    if (mazeGrid[currentCell.Row + i, currentCell.Col].Occupied)
                    {
                        mazeGrid[currentCell.Row + i, currentCell.Col].IsLegal = true;
                        break;
                    }
                    else
                    {
                        mazeGrid[currentCell.Row + i, currentCell.Col].IsLegal = true;
                    }
                }
            }

            // LEFT
            for (int j = 1; j < (currentCell.Col + 1); j++)
            {
                // check if next cell is occupied - if so then set as legal and exit the for loop
                if (mazeGrid[currentCell.Row, currentCell.Col - j].Occupied)
                {
                    mazeGrid[currentCell.Row, currentCell.Col - j].IsLegal = true;
                    break;
                }
                else
                {
                    mazeGrid[currentCell.Row, currentCell.Col - j].IsLegal = true;
                }
            }

            //  UP
            for (int i = 1; i <= currentCell.Row; i++)
            {
                // check if Up movement is valid
                if (currentCell.Row - i >= 0)
                {
                    // check if next cell is occupied
                    if (mazeGrid[currentCell.Row - i, currentCell.Col].Occupied)
                    {
                        mazeGrid[currentCell.Row - i, currentCell.Col].IsLegal = true;
                        break;
                    }
                    else
                    {
                        mazeGrid[currentCell.Row - i, currentCell.Col].IsLegal = true;
                    }
                }
            }
            //RIGHT
            for (int j = 1; j < Size - currentCell.Col; j++)
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

        protected void BishopMovement(Cell currentCell)
        {
            for (var i = 1; i < Size; ++i)
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
            for (var i = 1; i < Size; ++i)
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
            for (var i = 1; i < Size; ++i)
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
            for (var i = 1; i < Size; ++i)
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
        }

        protected void KnightMovement(Cell currentCell)
        {
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
        }

        protected void KingMovement(Cell currentCell)
        {
            int[,] targetPositions = new int[,]
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
        }

        public void NextLegalMove (Cell currentCell, Part piece)
        {
            ResetLegalCells();
            // display legal moves for each piece
            switch (piece)
            {
                case (Part)'N':
                    KnightMovement(currentCell);
                    break;

                case (Part)'B':
                    BishopMovement(currentCell);
                    break;

                case (Part)'Q':
                    // Diagonal movement
                    BishopMovement(currentCell);

                    // Vertical and horizontal movement
                    RookMovement(currentCell);
                    break;

                case (Part)'K':
                    KingMovement(currentCell);
                    break;

                case (Part)'R':
                    RookMovement(currentCell);
                    break;
            }
        }

        public void SetStartGame()
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
            MoveCount = 0;
        }

        public void ResetLegalCells()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    mazeGrid[x, y].IsLegal = false;
                }
            }
        }

        public Cell SetCurrentCell(int currentRow, int currentCol)
        {
            playerCell = this.mazeGrid[currentRow, currentCol];
            
            return playerCell;
        }

        public Cell SetOccupiedPiece(int occupiedRow, int occupiedCol, Part piece)
        {
            Cell occupiedCell = this.mazeGrid[occupiedRow, occupiedCol];
            // get x and y co-ords and check they're are within the board
            if (occupiedCell.isValid(Size))
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

        public Cell SetNextMove(int nextRow, int nextCol)
        {
            prevCell = playerCell;
            playerCell = mazeGrid[nextRow, nextCol];
            
            // Checks if next cell is a legal move and there is a piece there
            if (playerCell.IsLegal & playerCell.Occupied)
            {
                SetCurrentCell(nextRow, nextCol);
                AddToMoveCount();
                return playerCell;
            }
            else
            {
                //Console.WriteLine("Illegal Move");
                playerCell = prevCell;
                return playerCell;
            }
        }

        public Cell SetFinalCell(int finalRow, int finalCol)
        {
            finalCell = mazeGrid[finalRow, finalCol];
            return finalCell;
        }

        public int AddToMoveCount()
        {
            MoveCount += 1;

            return MoveCount;
        }
    }
}
