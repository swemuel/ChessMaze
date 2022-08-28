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
            Cell currentCell = newBoard.SetCurrentCell(4, 4);
            currentCell.Occupied = true;

            // calc all legal moves from current piece
            newBoard.NextLegalMove(4, 4, currentCell, (Part)'r');

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

                    if (c.Occupied == true)
                    {
                        Console.Write('X');
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
