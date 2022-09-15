using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChessMaze
{
    class Game : IGame
    {

        static Board newBoard = new Board(8);
        Stopwatch timer = new Stopwatch();

        public void Start()
        {
            // Reset Board
            newBoard.SetStartGame();

            //start timer
            timer.Start();

            // Set pieces on board
            Load();

            Cell currentCell = newBoard.playerCell;

            // calc all legal moves from current piece
            newBoard.NextLegalMove(currentCell, currentCell.Piece);

            // Display board with entered current cell + legal moves
            Program.printBoard(newBoard);
            
            Move();
        }

        public void Move()
        {
            // Input for next move
            Console.WriteLine("Enter next Row");
            int nextRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter next Column");
            int nextCol = int.Parse(Console.ReadLine());

            Cell nextCell = newBoard.SetNextMove(nextRow, nextCol);

            // Calc next legal moves
            newBoard.NextLegalMove(nextCell, nextCell.Piece);

            // Increase move count by 1
            newBoard.AddToMoveCount();

            // Display board
            Program.printBoard(newBoard);

            //Display Movecount
            GetMoveCount();
            Console.WriteLine("");

            // If not finished prompt for next move
            if (!IsFinished())
            {
                // Acting as a temp reset button
                Console.WriteLine("Press: R = Restart, U = Undo, Any other key = continue");
                string nextAction = Console.ReadLine();
                if (nextAction == "R" || nextAction == "r")
                {
                    Restart();
                }
                else if (nextAction == "U" || nextAction == "u")
                {
                    Undo();
                }
                else
                {
                    Move();
                }
            }
            // If finished display message, time taken, moves taken and close program
            else
            {
                Console.WriteLine("Congrats, You Win!");
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                string timeString = "Time taken: " + timeTaken.ToString(@"m\:ss");

                Console.WriteLine(timeString);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        public void Load()
        {
            // Set the co-ordinates for the current piece/cell
            newBoard.SetCurrentCell(0, 0);

            // Set final cell
            newBoard.SetFinalCell(2, 2);

            // Populate board
            newBoard.SetOccupiedPiece(0, 0, (Part)'R');
            newBoard.SetOccupiedPiece(0, 2, (Part)'N');
            newBoard.SetOccupiedPiece(1, 2, (Part)'Q');
            newBoard.SetOccupiedPiece(2, 2, (Part)'K');
            newBoard.SetOccupiedPiece(2, 0, (Part)'B');
            newBoard.SetOccupiedPiece(2, 1, (Part)'B');
        }

        public int GetMoveCount()
        {
            Console.WriteLine("Move Count: " + newBoard.MoveCount);
            return newBoard.MoveCount;
        }

        public void Undo()
        {
            Cell prevCell = newBoard.prevCell;

            newBoard.SetCurrentCell(prevCell.Row, prevCell.Col);

            // Calc next legal moves
            newBoard.NextLegalMove(prevCell, prevCell.Piece);

            // Increase move count by 1
            newBoard.MinusMoveCount();

            // Display board
            Program.printBoard(newBoard);

            //Display Movecount
            GetMoveCount();
            Console.WriteLine("");

            // Next move
            Move();
        }

        public void Restart()
        {
            Start();
        }

        public bool IsFinished()
        {
            if (newBoard.playerCell == newBoard.finalCell)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
