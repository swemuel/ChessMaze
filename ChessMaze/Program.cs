using System;

namespace ChessMaze
{
    class Program
    {
        static Board newBoard = new Board(8);

        static void Main(string[] args)
        {
            // Display empty chess board
            printBoard(newBoard);

            // Set the co-ordinates for the current piece/cell
            Cell currentCell = newBoard.SetStartGame(3, 3);
  
            // Set pieces on board
            newBoard.SetOccupiedPiece(2, 1, (Part)'N');
            newBoard.SetOccupiedPiece(3, 1, (Part)'N');
            newBoard.SetOccupiedPiece(4, 1, (Part)'N');
            newBoard.SetOccupiedPiece(5, 1, (Part)'N');
            newBoard.SetOccupiedPiece(1, 2, (Part)'N');
            newBoard.SetOccupiedPiece(1, 4, (Part)'B');
            newBoard.SetOccupiedPiece(2, 6, (Part)'B');
            newBoard.SetOccupiedPiece(4, 6, (Part)'N');
            newBoard.SetOccupiedPiece(6, 2, (Part)'B');
            newBoard.SetOccupiedPiece(6, 3, (Part)'Q');
            newBoard.SetOccupiedPiece(6, 4, (Part)'K');
            newBoard.SetOccupiedPiece(6, 6, (Part)'N');

            // calc all legal moves from current piece
            newBoard.NextLegalMove(currentCell, (Part)'q');

            // Display board with entered current cell + legal moves
            printBoard(newBoard);

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
