using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day04
{
    internal class Solution
    {
        public static string InputFile = "INPUT";

        public Solution(string inputFile = "INPUT")
        {
            InputFile = inputFile;
        }

        public List<Board> BoardsList { get; } = new();
        public List<int> DrawnNumbers { get; private set; } = new();

        public void FillDrawnNumbers()
        {
            DrawnNumbers = new InputReader(InputFile).ReadFileAsLines()[0].Split(',').Select(int.Parse).ToList();
        }

        public void FillBoardsList()
        {
            var lines = new InputReader(InputFile).ReadFileAsLines();

            // skip the first and the second line
            // filling row by row
            var row = 0;
            var board = new Board();
            for (var i = 2; i < lines.Length; i++)
            {
                if (row == 5)
                {
                    BoardsList.Add(board);
                    row = 0;
                    board = new Board();
                    continue;
                }

                board.FillRow(row, lines[i].Split(' ').Where(s => s != string.Empty).Select(int.Parse).ToList());
                row++;
            }
 
            BoardsList.Add(board);
        }

        public void DrawSingleNumber(int number)
        {
            foreach (var board in BoardsList) board.CheckCell(number);
        }

        public int PlayAndFindMyScore()
        {
            // draw first 5 number then check if we have bingo
            for (var i = 0; i < DrawnNumbers.Count; i++)
            {
                var drawnNumber = DrawnNumbers[i];
                DrawSingleNumber(DrawnNumbers[i]);

                if (i < 5) continue;

                var bingoList = BoardsList.Where(b => b.Bingo()).ToList();

                if (bingoList.Count == 1) return bingoList[0].SumNoChecked() * drawnNumber;
            }

            return 0;
        }

        public int UpdatedPlayAndFindMyScore()
        {
            // draw first 5 number then check if we have bingo
            for (var i = 0; i < DrawnNumbers.Count; i++)
            {
                var drawnNumber = DrawnNumbers[i];
                DrawSingleNumber(DrawnNumbers[i]);

                if (i < 5) continue;

                if (BoardsList.Count == 1)
                {
                    if (BoardsList[0].Bingo())
                    {
                        return BoardsList[0].SumNoChecked() * drawnNumber;
                    }
                }
                else
                {
                    BoardsList.RemoveAll(b => b.Bingo());
                }
            }

            return 0;
        }

    }
}