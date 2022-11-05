using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChessMaze
{
    public class Game : IGame
    {

        public static Board newBoard = new Board(8);
        public Stopwatch timer = new Stopwatch();

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
            //Program.printBoard(newBoard);

            //SelectNextMove();
        }

        public int[,] GetPlayerCell()
        {
            int[,] playerCell = new int[,] { { newBoard.playerCell.Row, newBoard.playerCell.Col } };
            return playerCell;
        }

        public int[,] GetFinalCell()
        {
            int[,] finalCell = new int[,] { { newBoard.finalCell.Row, newBoard.finalCell.Col } };
            return finalCell;
        }

        // takes user input fo rnext move
        public void InputNextMove()
        {
            // Input for next move
            Console.WriteLine("Enter next Row");
            int nextRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter next Column");
            int nextCol = int.Parse(Console.ReadLine());

            Move(nextRow, nextCol);
        }

        // handles movement with input params from InputNextMove()
        public int[,] Move(int nextRow, int nextCol)
        {
            Cell nextCell = newBoard.SetNextMove(nextRow, nextCol);

            // Calc next legal moves
            newBoard.NextLegalMove(nextCell, nextCell.Piece);

            // Increase move count by 1
            newBoard.AddToMoveCount();

            // Display board
            // Program.printBoard(newBoard);

            //Display Movecount
            GetMoveCount();
            Console.WriteLine("");

            return GetPlayerCell();
        }

        // Checks for Restart or Undo
        public void SetNextMove() { 
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
                    InputNextMove();
                }
            }
            // If finished display message, time taken, moves taken and close program
            else
            {
                End();
                Console.WriteLine(GetTime());
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        public string GetTime()
        {
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string timeString = "Time taken: " + timeTaken.ToString(@"m\:ss");
            return timeString;
        }
            
        public void Load()
        {
            // Set the co-ordinates for the current piece/cell
            newBoard.SetCurrentCell(0, 0);

            newBoard.prevCell = newBoard.mazeGrid[0,0];
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

        public void AddPiece(int row, int col, Part piece)
        {
            newBoard.SetOccupiedPiece(row, col, piece);
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
           // Program.printBoard(newBoard);

            //Display Movecount
            GetMoveCount();
            //Console.WriteLine("");

            // Next move
            //SelectFirstMove();
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

        public string End()
        {
            return "Congrats, You Win!";
        }
    }
}
