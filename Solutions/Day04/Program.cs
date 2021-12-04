using System;

namespace AdventOfCode.Day04
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            solution.FillDrawnNumbers();
            solution.FillBoardsList();
            var score = solution.PlayAndFindMyScore();
            Console.WriteLine("Score for task 1 is {0}", score);
            // 46920
            //
            Console.WriteLine("Solving task 2!");
            solution = new Solution();
            solution.FillDrawnNumbers();
            solution.FillBoardsList();
            score = solution.UpdatedPlayAndFindMyScore();
            Console.WriteLine("Score for task 2 is {0}", score);
            // 12635
        }
    }
}