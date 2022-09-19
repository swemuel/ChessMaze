using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessMaze;

namespace ChessMazeTest
{
    [TestClass]
    public class BoardTests
    {
        private Boar theBoard = new Boar(8);
        private Game theGame = new Game();


        // Feature 1 - Must have a game board with cells
        [TestMethod]
        public void TestGameBoardSizeis8()
        {
            int expectedBoardSize = 8;
            int actualBoardSize = theBoard.Size;
            Assert.AreEqual(expectedBoardSize, actualBoardSize);
        }

        [TestMethod]
        public void TestGameBoardIsNotEmpty()
        {
            int emptyBoard = 0;
            int actualBoardSize = theBoard.mazeGrid.GetLength(0);
            Assert.AreNotEqual(emptyBoard, actualBoardSize);
        }


        // Feature 2 - Must have ability to select next move
        Cell SetNextMove(int row, int col)
        {
            theGame.Move(row, col);
            return theGame.GetPlayerCell();
        }

        [TestMethod]
        public void TestNextMoveHasBeenSet()
        {
            theGame.Start();
            Cell nextMove = SetNextMove(0, 2);

            int expectedCol = 2;
            int expectedRow = 0;
            int actualCol = nextMove.Col;
            int actualRow = nextMove.Row;

            Assert.AreEqual(expectedCol, actualCol);
            Assert.AreEqual(expectedRow, actualRow);
        }

        [TestMethod]
        public void TestNextMoveHasBeenSet2()
        {
            theGame.Start();
            Cell nextMove = SetNextMove(2, 0);

            int expectedCol = 0;
            int expectedRow = 2;
            int actualCol = nextMove.Col;
            int actualRow = nextMove.Row;

            Assert.AreEqual(expectedCol, actualCol);
            Assert.AreEqual(expectedRow, actualRow);
        }


        // Feature 3 - Must have correct movement for rook
        Boar SetBoardWithPart(Part piece)
        {
            Boar newBoard = theBoard;
            Cell newCell = newBoard.SetCurrentCell(3, 3);
            newCell.Piece = piece;
            newBoard.NextLegalMove(newCell, newCell.Piece);
            return newBoard;
        }

        [TestMethod]
        public void TestCorrectRookMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Rook);

            //Testing horizontal and vertical limits
            bool expectedLegalCell1 = newBoard.mazeGrid[0, 3].IsLegal;
            bool expectedLegalCell2 = newBoard.mazeGrid[3, 0].IsLegal;
            bool expectedLegalCell3 = newBoard.mazeGrid[3, 7].IsLegal;
            bool expectedLegalCell4 = newBoard.mazeGrid[7, 3].IsLegal;

            Assert.IsTrue(expectedLegalCell1);
            Assert.IsTrue(expectedLegalCell2);
            Assert.IsTrue(expectedLegalCell3);
            Assert.IsTrue(expectedLegalCell4);
        }

        [TestMethod]
        public void TestIncorrectRookMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Rook);

            //Testing all the diagonals
            bool expectedIllegalCell1 = newBoard.mazeGrid[4, 4].IsLegal;
            bool expectedIllegalCell2 = newBoard.mazeGrid[2, 4].IsLegal;
            bool expectedIllegalCell3 = newBoard.mazeGrid[2, 4].IsLegal;
            bool expectedIllegalCell4 = newBoard.mazeGrid[2, 2].IsLegal;

            Assert.IsFalse(expectedIllegalCell1);
            Assert.IsFalse(expectedIllegalCell2);
            Assert.IsFalse(expectedIllegalCell3);
            Assert.IsFalse(expectedIllegalCell4);
        }


        // Feature 4 - Must have correct movement for bishop
        [TestMethod]
        public void TestCorrectBishopMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Bishop);

            //Testing all the diagonals
            bool expectedLegalCell1 = newBoard.mazeGrid[7, 7].IsLegal;
            bool expectedLegalCell2 = newBoard.mazeGrid[0, 0].IsLegal;
            bool expectedLegalCell3 = newBoard.mazeGrid[6, 0].IsLegal;
            bool expectedLegalCell4 = newBoard.mazeGrid[0, 6].IsLegal;

            Assert.IsTrue(expectedLegalCell1);
            Assert.IsTrue(expectedLegalCell2);
            Assert.IsTrue(expectedLegalCell3);
            Assert.IsTrue(expectedLegalCell4);
        }

        [TestMethod]
        public void TestIncorrectBishopMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Bishop);

            //Testing horzontal/vertical positions
            bool expectedIllegalCell1 = newBoard.mazeGrid[3, 7].IsLegal;
            bool expectedIllegalCell2 = newBoard.mazeGrid[3, 0].IsLegal;
            bool expectedIllegalCell3 = newBoard.mazeGrid[0, 3].IsLegal;
            bool expectedIllegalCell4 = newBoard.mazeGrid[7, 3].IsLegal;

            Assert.IsFalse(expectedIllegalCell1);
            Assert.IsFalse(expectedIllegalCell2);
            Assert.IsFalse(expectedIllegalCell3);
            Assert.IsFalse(expectedIllegalCell4);
        }


        // Feature 5 - Must have correct movement for Knight
        [TestMethod]
        public void TestCorrectKnightMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Knight);

            bool expectedLegalCell1 = newBoard.mazeGrid[1, 4].IsLegal;
            bool expectedLegalCell2 = newBoard.mazeGrid[1, 2].IsLegal;
            bool expectedLegalCell3 = newBoard.mazeGrid[2, 5].IsLegal;
            bool expectedLegalCell4 = newBoard.mazeGrid[2, 1].IsLegal;
            bool expectedLegalCell5 = newBoard.mazeGrid[4, 5].IsLegal;
            bool expectedLegalCell6 = newBoard.mazeGrid[4, 1].IsLegal;
            bool expectedLegalCell7 = newBoard.mazeGrid[5, 4].IsLegal;
            bool expectedLegalCell8 = newBoard.mazeGrid[5, 2].IsLegal;

            Assert.IsTrue(expectedLegalCell1);
            Assert.IsTrue(expectedLegalCell2);
            Assert.IsTrue(expectedLegalCell3);
            Assert.IsTrue(expectedLegalCell4);
            Assert.IsTrue(expectedLegalCell5);
            Assert.IsTrue(expectedLegalCell6);
            Assert.IsTrue(expectedLegalCell7);
            Assert.IsTrue(expectedLegalCell8);
        }


        [TestMethod]
        public void TestIncorrectKnightMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Knight);

            //Testing cells surrounding current cell
            bool expectedIllegalCell1 = newBoard.mazeGrid[3, 4].IsLegal;
            bool expectedIllegalCell2 = newBoard.mazeGrid[3, 2].IsLegal;
            bool expectedIllegalCell3 = newBoard.mazeGrid[2, 3].IsLegal;
            bool expectedIllegalCell4 = newBoard.mazeGrid[4, 3].IsLegal;

            Assert.IsFalse(expectedIllegalCell1);
            Assert.IsFalse(expectedIllegalCell2);
            Assert.IsFalse(expectedIllegalCell3);
            Assert.IsFalse(expectedIllegalCell4);
        }


        // Feature 6 - Must have correct movement for queen
        [TestMethod]
        public void TestCorrectQueenMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Queen);

            //Testing all the diagonals
            bool expectedLegalCell1 = newBoard.mazeGrid[7, 7].IsLegal;
            bool expectedLegalCell2 = newBoard.mazeGrid[0, 0].IsLegal;
            bool expectedLegalCell3 = newBoard.mazeGrid[6, 0].IsLegal;
            bool expectedLegalCell4 = newBoard.mazeGrid[0, 6].IsLegal;

            //Test horizontal/vertical
            bool expectedLegalCell5 = newBoard.mazeGrid[0, 3].IsLegal;
            bool expectedLegalCell6 = newBoard.mazeGrid[3, 0].IsLegal;
            bool expectedLegalCell7 = newBoard.mazeGrid[3, 7].IsLegal;
            bool expectedLegalCell8 = newBoard.mazeGrid[7, 3].IsLegal;

            Assert.IsTrue(expectedLegalCell1);
            Assert.IsTrue(expectedLegalCell2);
            Assert.IsTrue(expectedLegalCell3);
            Assert.IsTrue(expectedLegalCell4);
            Assert.IsTrue(expectedLegalCell5);
            Assert.IsTrue(expectedLegalCell6);
            Assert.IsTrue(expectedLegalCell7);
            Assert.IsTrue(expectedLegalCell8);
        }

        [TestMethod]
        public void TestIncorrectQueenMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.Queen);

            //Testing cells That the queen won't reach
            bool expectedIllegalCell1 = newBoard.mazeGrid[1, 4].IsLegal;
            bool expectedIllegalCell2 = newBoard.mazeGrid[4, 1].IsLegal;
            bool expectedIllegalCell3 = newBoard.mazeGrid[5, 2].IsLegal;
            bool expectedIllegalCell4 = newBoard.mazeGrid[2, 5].IsLegal;

            Assert.IsFalse(expectedIllegalCell1);
            Assert.IsFalse(expectedIllegalCell2);
            Assert.IsFalse(expectedIllegalCell3);
            Assert.IsFalse(expectedIllegalCell4);
        }


        // Feature 7 - Must have correct movement for king
        [TestMethod]
        public void TestCorrectKingMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.King);

            bool expectedLegalCell1 = newBoard.mazeGrid[3, 4].IsLegal;
            bool expectedLegalCell2 = newBoard.mazeGrid[3, 2].IsLegal;
            bool expectedLegalCell3 = newBoard.mazeGrid[4, 3].IsLegal;
            bool expectedLegalCell4 = newBoard.mazeGrid[2, 3].IsLegal;
            bool expectedLegalCell5 = newBoard.mazeGrid[4, 4].IsLegal;
            bool expectedLegalCell6 = newBoard.mazeGrid[2, 2].IsLegal;
            bool expectedLegalCell7 = newBoard.mazeGrid[4, 2].IsLegal;
            bool expectedLegalCell8 = newBoard.mazeGrid[2, 4].IsLegal;

            Assert.IsTrue(expectedLegalCell1);
            Assert.IsTrue(expectedLegalCell2);
            Assert.IsTrue(expectedLegalCell3);
            Assert.IsTrue(expectedLegalCell4);
            Assert.IsTrue(expectedLegalCell5);
            Assert.IsTrue(expectedLegalCell6);
            Assert.IsTrue(expectedLegalCell7);
            Assert.IsTrue(expectedLegalCell8);
        }

        [TestMethod]
        public void TestIncorrectKingMovement()
        {
            Boar newBoard = SetBoardWithPart(Part.King);

            //Testing 2 steps from current isn't legal
            bool expectedIllegalCell1 = newBoard.mazeGrid[5, 5].IsLegal;
            bool expectedIllegalCell2 = newBoard.mazeGrid[1, 1].IsLegal;
            bool expectedIllegalCell3 = newBoard.mazeGrid[5, 5].IsLegal;
            bool expectedIllegalCell4 = newBoard.mazeGrid[1, 1].IsLegal;

            Assert.IsFalse(expectedIllegalCell1);
            Assert.IsFalse(expectedIllegalCell2);
            Assert.IsFalse(expectedIllegalCell3);
            Assert.IsFalse(expectedIllegalCell4);
        }

        // Feature 14 - Must have Reset
        [TestMethod]
        public void TestResetButtonWorks()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            Cell preResetCell = theGame.GetPlayerCell();

            theGame.Restart();
            Cell currentcell = theGame.GetPlayerCell();

            int expectedPreResetCol = 1;
            int expectedPreResetRow = 2;
            int actualPreResetCol = preResetCell.Col;
            int actualPreResetRow = preResetCell.Row;

            int expectedResetCol = 0;
            int expectedResetRow = 0;
            int actualCol = currentcell.Col;
            int actualRow = currentcell.Row;

            Assert.AreEqual(expectedPreResetCol, actualPreResetCol);
            Assert.AreEqual(expectedPreResetRow, actualPreResetRow);

            Assert.AreEqual(expectedResetCol, actualCol);
            Assert.AreEqual(expectedResetRow, actualRow);
        }

        // Once the game is complete you should still be able to reset
        [TestMethod]
        public void TestResetButtonWorksAfterCompletion()
        {
            theGame.Start();
            theGame.Move(0, 2);
            theGame.Move(2, 1);
            theGame.Move(1, 2);
            theGame.Move(2, 2);
            theGame.End();
            Cell preResetCell = theGame.GetPlayerCell();

            theGame.Restart();
            Cell currentcell = theGame.GetPlayerCell();

            int expectedPreResetCol = 2;
            int expectedPreResetRow = 2;
            int actualPreResetCol = preResetCell.Col;
            int actualPreResetRow = preResetCell.Row;

            int expectedResetCol = 0;
            int expectedResetRow = 0;
            int actualCol = currentcell.Col;
            int actualRow = currentcell.Row;

            Assert.AreEqual(expectedPreResetCol, actualPreResetCol);
            Assert.AreEqual(expectedPreResetRow, actualPreResetRow);

            Assert.AreEqual(expectedResetCol, actualCol);
            Assert.AreEqual(expectedResetRow, actualRow);
        }


        // Feature 13 - Must have undo button
        [TestMethod]
        public void TestUndoButtonWorks()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            Cell preResetCell = theGame.GetPlayerCell();

            theGame.Undo();
            Cell currentcell = theGame.GetPlayerCell();

            int expectedPreResetCol = 1;
            int expectedPreResetRow = 2;
            int actualPreResetCol = preResetCell.Col;
            int actualPreResetRow = preResetCell.Row;

            int expectedResetCol = 2;
            int expectedResetRow = 0;
            int actualCol = currentcell.Col;
            int actualRow = currentcell.Row;

            Assert.AreEqual(expectedPreResetCol, actualPreResetCol);
            Assert.AreEqual(expectedPreResetRow, actualPreResetRow);

            Assert.AreEqual(expectedResetCol, actualCol);
            Assert.AreEqual(expectedResetRow, actualRow);
        }

        // test that the undo button doesnt break the start position
        [TestMethod]
        public void TestUndoButtonWorksOnlyWhereApplicable()
        {
            theGame.Start();
            Cell preResetCell = theGame.GetPlayerCell();

            theGame.Undo();
            Cell currentcell = theGame.GetPlayerCell();

            int expectedPreResetCol = 0;
            int expectedPreResetRow = 0;
            int actualPreResetCol = preResetCell.Col;
            int actualPreResetRow = preResetCell.Row;

            int expectedResetCol = 0;
            int expectedResetRow = 0;
            int actualCol = currentcell.Col;
            int actualRow = currentcell.Row;

            Assert.AreEqual(expectedPreResetCol, actualPreResetCol);
            Assert.AreEqual(expectedPreResetRow, actualPreResetRow);

            Assert.AreEqual(expectedResetCol, actualCol);
            Assert.AreEqual(expectedResetRow, actualRow);
        }


        // Feature 12 - Must have end co-ordinates
        [TestMethod]
        public void TestEndPosition()
        {
            theGame.Start();
            Cell finalCell = theGame.GetFinalCell();

            int expectedFinalRow = 2;
            int expectedFinalCol = 2;

            int actualFinalRow = finalCell.Row;
            int actualFinalCol = finalCell.Col;

            Assert.AreEqual(expectedFinalRow, actualFinalRow);
            Assert.AreEqual(expectedFinalCol, actualFinalCol);
        }

        // test game ends at end position (2,2)
        [TestMethod]
        public void GameEndsAtEndPosition()
        {
            theGame.Start();
            theGame.Move(0,2);
            theGame.Move(2, 1);
            theGame.Move(1, 2);
            theGame.Move(2, 2);

            bool gameEnded = theGame.IsFinished();

            Assert.IsTrue(gameEnded);
        }


        // Feature 11 - Must have Start co-ordinates
        [TestMethod]
        public void TestStartPosition()
        {
            theGame.Start();
            Cell startCell = theGame.GetPlayerCell();

            int expectedStartRow = 0;
            int expectedStartCol = 0;

            int actualStartRow = startCell.Row;
            int actualStartCol = startCell.Col;

            Assert.AreEqual(expectedStartRow, actualStartRow);
            Assert.AreEqual(expectedStartCol, actualStartCol);
        }

        [TestMethod]
        public void TestNotStartPosition()
        {
            theGame.Start();
            Cell startCell = theGame.GetPlayerCell();

            int unexpectedStartRow = 1;
            int unexpectedStartCol = 1;

            int actualStartRow = startCell.Row;
            int actualStartCol = startCell.Col;

            Assert.AreNotEqual(unexpectedStartRow, actualStartRow);
            Assert.AreNotEqual(unexpectedStartCol, actualStartCol);
        }


        // Feature 10 - Must have Move Counter
        [TestMethod]
        public void Test2MoveCounter()
        {
            theGame.Start();
            SetNextMove(0, 2); 
            SetNextMove(2, 1);
            int moveCount = theGame.GetMoveCount();

            int expectedMoveCount = 2;
            int actualMoveCount = moveCount;

            Assert.AreEqual(expectedMoveCount, actualMoveCount);
        }

        [TestMethod]
        public void Test4MoveCounter()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(1, 2);
            SetNextMove(2, 2);
            int moveCount = theGame.GetMoveCount();

            int expectedMoveCount = 4;
            int actualMoveCount = moveCount;

            Assert.AreEqual(expectedMoveCount, actualMoveCount);
        }


        // Feature 16 - Must display Time Take
        [TestMethod]
        public void TestTimeTaken()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            string timeTaken = theGame.GetTime();

            string expectedTimeTaken = "Time taken: 0:00";
            string actualTimeTaken = timeTaken;

            Assert.AreEqual(expectedTimeTaken, actualTimeTaken);
        }

        [TestMethod]
        public void TestLongerTimeTaken()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(1, 2);
            System.Threading.Thread.Sleep(2000);
            SetNextMove(2, 2);
            
            
            string timeTaken = theGame.GetTime();

            string expectedTimeTaken = "Time taken: 0:02";
            string actualTimeTaken = timeTaken;

            Assert.AreEqual(expectedTimeTaken, actualTimeTaken);
        }


        // Feature 15 - Must acknowledge level completion
        [TestMethod]
        public void TestLevelCompletion()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(1, 2);
            SetNextMove(2, 2);
            bool levelComplete = theGame.IsFinished();

            Assert.IsTrue(levelComplete);
        }

        [TestMethod]
        public void TestLevelIncomplete()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(1, 2);
            bool levelComplete = theGame.IsFinished();

            Assert.IsFalse(levelComplete);
        }


        // Feature 9 - Must not accept empty cell
        [TestMethod]
        public void TestEmptyCellRejection()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(1, 2);
            SetNextMove(2, 3); // empty cell
            Cell currentCell = theGame.GetPlayerCell();

            // playerCell should not change to empty cell
            int expectedCurrentRow = 1;
            int expectedCurrentCol = 2;

            int actualCurrentRow = currentCell.Row;
            int actualCurrentCol = currentCell.Col;

            Assert.AreEqual(expectedCurrentRow, actualCurrentRow);
            Assert.AreEqual(expectedCurrentCol, actualCurrentCol);
        }

        [TestMethod]
        public void TestOccupiedCellAcception()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(1, 2);
            theGame.AddPiece(2, 3, (Part)'R');
            SetNextMove(2, 3); 
            Cell currentCell = theGame.GetPlayerCell();

            // playerCell should be able to move to (2,3)
            int expectedCurrentRow = 2;
            int expectedCurrentCol = 3;

            int actualCurrentRow = currentCell.Row;
            int actualCurrentCol = currentCell.Col;

            Assert.AreEqual(expectedCurrentRow, actualCurrentRow);
            Assert.AreEqual(expectedCurrentCol, actualCurrentCol);
        }


        // Feature 8 - Must not accept Incorrect movement
        [TestMethod]
        public void TestIncorrectQueenDirectionRejection()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(1, 2);
            SetNextMove(0, 0); // occupied, but incorrect direction for queen
            Cell currentCell = theGame.GetPlayerCell();

            // playerCell should not change to empty cell
            int expectedCurrentRow = 1;
            int expectedCurrentCol = 2;

            int actualCurrentRow = currentCell.Row;
            int actualCurrentCol = currentCell.Col;

            Assert.AreEqual(expectedCurrentRow, actualCurrentRow);
            Assert.AreEqual(expectedCurrentCol, actualCurrentCol);
        }

        [TestMethod]
        public void TestIncorrectBishopDirectionRejection()
        {
            theGame.Start();
            SetNextMove(0, 2);
            SetNextMove(2, 1);
            SetNextMove(0, 0); // occupied, but incorrect direction for bishop
            Cell currentCell = theGame.GetPlayerCell();

            // playerCell should not change to empty cell
            int expectedCurrentRow = 2;
            int expectedCurrentCol = 1;

            int actualCurrentRow = currentCell.Row;
            int actualCurrentCol = currentCell.Col;

            Assert.AreEqual(expectedCurrentRow, actualCurrentRow);
            Assert.AreEqual(expectedCurrentCol, actualCurrentCol);
        }
    }
}
