using System;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day05
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            var lines = new InputReader(Solution.InputFile).ReadFileAsLines();
            solution.FillTheGrid(lines);
            var points = solution.CalculateOverlappingPoints();
        
            Console.WriteLine("Points for task 1 is {0}", points);
            // // 8060

            Console.WriteLine("Solving task 2!");
            solution = new Solution();
            solution.FillTheGrid(lines, false);
             points = solution.CalculateOverlappingPoints();
        
            Console.WriteLine("Points for task 2 is {0}", points);
            // // 21577
        }
    }
}