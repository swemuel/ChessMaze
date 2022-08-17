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

            // close on next key press
            Console.ReadLine();
        }

        private static void printBoard(Board newBoard)
        {
            // display chess board: 'X' = current piece, '+' = legal next move, E = empty
            for (int x = 0; x < newBoard.Size; x++)
            {
                for (int y = 0; y < newBoard.Size; y++)
                {
                    Cell c = newBoard.mazeGrid[x, y];

                    if (c.Occupied == true)
                    {
                        Console.Write('X');
                    }
                    else if (c.IsLegal == true)
                    {
                        Console.Write('+');
                    }
                    else
                    {
                        Console.Write("E");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("====================");
        }
    }
}
