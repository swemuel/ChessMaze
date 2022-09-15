using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessMaze;

namespace ChessMazeTest
{
    [TestClass]
    public class BoardTests
    {
        private Board theBoard = new Board(8);

        [TestMethod]
        public void TestGameBoardHasCells ()
        {
            int expectedBoardSize = 8;
            int actualBoardSize = theBoard.Size;
            Assert.AreEqual(expectedBoardSize, actualBoardSize);
        }
    }
}
