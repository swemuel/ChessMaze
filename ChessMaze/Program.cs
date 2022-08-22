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
            Cell currentCell = setCurrentCell();
            currentCell.Occupied = true;

            // calc all legal moves from current piece
            newBoard.NextLegalMove(currentCell, (Part)'n');

            // Display board with entered current cell + legal moves
            printBoard(newBoard);

            // close on next key press
            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            // get x and y co-ords from user and return the cell location
            Console.WriteLine("Enter the current row number");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the current row number");
            int currentCol = int.Parse(Console.ReadLine());

            return newBoard.mazeGrid[currentRow, currentCol];
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
                    else if (c.IsLegal == true)
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
