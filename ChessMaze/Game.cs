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
        }

        public int[,] GetPlayerCell()
        {
            int[,] playerCell = new int[,] { { newBoard.playerCell.Row, newBoard.playerCell.Col } };
            return playerCell;
        }

        public int[,] GetPrevCell()
        {
            int[,] prevCell = new int[,] { { newBoard.prevCell.Row, newBoard.prevCell.Col } };
            return prevCell;
        }

        public int[,] GetFinalCell()
        {
            int[,] finalCell = new int[,] { { newBoard.finalCell.Row, newBoard.finalCell.Col } };
            return finalCell;
        }

        // handles movement with input params from InputNextMove()
        public int[,] Move(int nextRow, int nextCol)
        {
            Cell nextCell = newBoard.SetNextMove(nextRow, nextCol);

            // Calc next legal moves
            newBoard.NextLegalMove(nextCell, nextCell.Piece);
            
            // Display board
            // Program.printBoard(newBoard);

            //Display Movecount
            GetMoveCount();
            Console.WriteLine("");

            return GetPlayerCell();
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
