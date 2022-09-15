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

            Console.WriteLine("Enter next Row");
            int nextRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter next Column");
            int nextCol = int.Parse(Console.ReadLine());

            Cell nextCell = newBoard.SetNextMove(nextRow, nextCol);

            newBoard.NextLegalMove(nextCell, nextCell.Piece);
            newBoard.AddToMoveCount();
            Program.printBoard(newBoard);
            GetMoveCount();

            

            
           
            // If not finished prompt for next move
            if (!IsFinished())
            {
                // Acting as a temp reset button
                Console.WriteLine("Press R to Restart Or any other key to continue");
                string r = Console.ReadLine();
                if (r == "R" || r == "r")
                {
                    Restart();
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
                string timeString = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");

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
