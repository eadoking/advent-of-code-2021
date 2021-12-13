using System;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day11
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            var score = solution.CalculateFlashesAfter(100);
            
            Console.WriteLine("score for task 1 is {0}", score);
            // // // 1667
            // //
            //
            Console.WriteLine("Solving task 2!");
             solution = new Solution();
             score = solution.CalculateFirstSyncPoint();
            
            Console.WriteLine("first sync point for task 2 is {0}", score);
            // // // // 488
        }
    }
}