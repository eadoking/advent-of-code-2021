using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Day04
{
    public class UnitTests
    {
        private const string InputTestFile = "INPUT_TEST";
        private static  List<Board> ExpectedBoardsList = new List<Board>();
        private Solution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Solution(InputTestFile);
        }

        [SetUp]
        public void SetupBeforeEachTest()
        {
            ExpectedBoardsList = new List<Board>();
            var board = new Board();
            board.FillBoard(
                new[,]
                {
                    {22, 13, 17, 11, 0},
                    {8, 2, 23, 4, 24},
                    {21, 9, 14, 16, 7},
                    {6, 10, 3, 18, 5},
                    {1, 12, 20, 15, 19}
                });
            ExpectedBoardsList.Add(board);

            board = new Board();
            board.FillBoard(
                new[,]
                {
                    {3, 15, 0, 2, 22},
                    {9, 18, 13, 17, 5},
                    {19, 8, 7, 25, 23},
                    {20, 11, 10, 24, 4},
                    {14, 21, 16, 12, 6}
                });
            ExpectedBoardsList.Add(board);

            board = new Board();
            board.FillBoard(
                new[,]
                {
                    {14, 21, 17, 24, 4},
                    {10, 16, 15, 9, 19},
                    {18, 8, 23, 26, 20},
                    {22, 11, 13, 6, 5},
                    {2, 0, 12, 3, 7}
                });
            ExpectedBoardsList.Add(board);
        }


        [TestCase(ExpectedResult = new[]
            {7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1})]
        public int[] TestFillDrawnNumbers()
        {
            _solution.FillDrawnNumbers();
            return _solution.DrawnNumbers.ToArray();
        }

        [Test]
        public void TestFillBoardsList()
        {
            _solution.FillBoardsList();
            Assert.AreEqual(ExpectedBoardsList,  _solution.BoardsList);
        }

        [TestCase(ExpectedResult = 4512)]
        public int TestPlayAndFindMyScore()
        {
            _solution.FillDrawnNumbers();
            _solution.FillBoardsList();
            return _solution.PlayAndFindMyScore();
        }

        [TestCase(ExpectedResult = 1924)]
        public int TestUpdatedPlayAndFindMyScore()
        {
            _solution.FillDrawnNumbers();
            _solution.FillBoardsList();
            return _solution.UpdatedPlayAndFindMyScore();
        }

        [TestCase(ExpectedResult = 300)]
        public int TestBoardSumNoChecked()
        {
            var board = new Board();
            board.FillBoard(
                new[,]
                {
                    {22, 13, 17, 11, 0},
                    {8, 2, 23, 4, 24},
                    {21, 9, 14, 16, 7},
                    {6, 10, 3, 18, 5},
                    {1, 12, 20, 15, 19}
                });

            return board.SumNoChecked();
        }

        [TestCase(ExpectedResult = 285)]
        public int TestBoardSumNoCheckedWithChceckedCells()
        {
            var board = new Board();
            board.FillBoard(
                new[,]
                {
                    {22, 13, 17, 11, 0},
                    {8, 2, 23, 4, 24},
                    {21, 9, 14, 16, 7},
                    {6, 10, 3, 18, 5},
                    {1, 12, 20, 15, 19}
                });

            board.CheckCell(2);
            board.CheckCell(12);
            board.CheckCell(1);

            return board.SumNoChecked();
        }

        [TestCase(ExpectedResult = true)]
        public bool TestBoardSBingo()
        {
            var board = new Board();
            board.FillBoard(
                new[,]
                {
                    {22, 13, 17, 11, 0},
                    {8, 2, 23, 4, 24},
                    {21, 9, 14, 16, 7},
                    {6, 10, 3, 18, 5},
                    {1, 12, 20, 15, 19}
                });

            board.CheckCell(21);
            board.CheckCell(9);
            board.CheckCell(14);
            board.CheckCell(16);
            board.CheckCell(7);
            return board.Bingo();
        }

        [TestCase(ExpectedResult = false)]
        public bool TestBoardSBingoNoBingo()
        {
            var board = new Board();
            board.FillBoard(
                new[,]
                {
                    {22, 13, 17, 11, 0},
                    {8, 2, 23, 4, 24},
                    {21, 9, 14, 16, 7},
                    {6, 10, 3, 18, 5},
                    {1, 12, 20, 15, 19}
                });

            board.CheckCell(21);
            board.CheckCell(9);
            board.CheckCell(14);
            board.CheckCell(16);
            return board.Bingo();
        }
    }
}