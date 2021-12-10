using System;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day10
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            var score = solution.CalculateSyntaxErrorScore();
            
            Console.WriteLine("score for task 1 is {0}", score);
            // // // 462693
            // //
            //
            Console.WriteLine("Solving task 2!");
             // solution = new Solution();
             score = solution.CalculateMiddleScore();
            
            Console.WriteLine("middle score for task 2 is {0}", score);
            // // // // 3094671161
        }
    }
}