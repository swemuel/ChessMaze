using System;
using System.Diagnostics;

namespace ChessMaze
{
    class Program
    {
        static Board newBoard = new Board(8);

        static Game newGame = new Game();

        static void Main(string[] args)
        {
            // Display empty chess board
            newGame.Start();
        }

        public static void printBoard(Board newBoard)
        {
            // display chess board: 'X' = current piece, '+' = legal next move, . = empty
            for (int x = 0; x < newBoard.Size; x++)
            {
                for (int y = 0; y < newBoard.Size; y++)
                {
                    Cell c = newBoard.mazeGrid[x, y];

                    if (c == newBoard.playerCell)
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
