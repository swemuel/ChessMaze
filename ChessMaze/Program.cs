using System;
using System.Diagnostics;

namespace ChessMaze
{
    class Program
    {
        static Board newBoard = new Board(8);
        
        

        static void Main(string[] args)
        {
            // Display empty chess board
            printBoard(newBoard);

            // Reset Board
            newBoard.SetStartGame();

            // Set the co-ordinates for the current piece/cell
            Cell currentCell = newBoard.SetCurrentCell(3, 3);

            var timer = new Stopwatch();
            timer.Start();

            // Add to move count
            newBoard.AddMoveCount();
  
            // Set pieces on board
            newBoard.SetOccupiedPiece(2, 1, (Part)'N');
            newBoard.SetOccupiedPiece(3, 1, (Part)'N');
            newBoard.SetOccupiedPiece(3, 3, (Part)'Q');
            newBoard.SetOccupiedPiece(4, 1, (Part)'N');
            newBoard.SetOccupiedPiece(5, 1, (Part)'N');
            newBoard.SetOccupiedPiece(1, 2, (Part)'N');
            newBoard.SetOccupiedPiece(0, 4, (Part)'B');
            newBoard.SetOccupiedPiece(2, 6, (Part)'B');
            newBoard.SetOccupiedPiece(4, 6, (Part)'N');
            newBoard.SetOccupiedPiece(6, 2, (Part)'B');
            newBoard.SetOccupiedPiece(6, 3, (Part)'Q');
            newBoard.SetOccupiedPiece(6, 4, (Part)'K');

            // calc all legal moves from current piece
            newBoard.NextLegalMove(currentCell, currentCell.Piece);

            // Display board with entered current cell + legal moves
            printBoard(newBoard);


            // Intial board state complete - can begin next move


            // 
            // set next move 
            Cell nextCell = newBoard.SetNextMove(1, 2, currentCell);

            // Add to move count
            newBoard.AddMoveCount();

            //
            newBoard.ResetLegalCells();

            //calc new legal moves
            newBoard.NextLegalMove(nextCell, nextCell.Piece);

            // Display move count
            Console.WriteLine("Move Count: " + newBoard.MoveCount);

            // Display board with next move
            printBoard(newBoard);

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");

            Console.WriteLine(foo);

            // close on next key press
            Console.ReadLine();
        }

        private static void printBoard(Board newBoard)
        {
            // display chess board: 'X' = current piece, '+' = legal next move, . = empty
            for (int x = 0; x < newBoard.Size; x++)
            {
                for (int y = 0; y < newBoard.Size; y++)
                {
                    Cell c = newBoard.mazeGrid[x, y];

                    if (c.playerCell)
                    {
                        Console.Write('X');
                    }
                    else if (c.Occupied == true)
                    {
                        switch (c.Piece)
                        {
                            case (Part)'N':
                                Console.Write('N');
                                break;

                            case (Part)'B':
                                Console.Write('B');
                                break;

                            case (Part)'R':
                                Console.Write('R');
                                break;

                            case (Part)'Q':
                                Console.Write('Q');
                                break;

                            case (Part)'K':
                                Console.Write('K');
                                break;

                            default:
                                Console.Write('X');
                                break;
                        }
                    }
                    else if (c.IsLegal == true && c.isValid())
                    {
                        Console.Write('+');
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("====================");
        }
    }
}
