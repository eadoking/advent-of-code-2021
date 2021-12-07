using System;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day07
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            solution.InitializePositions();
            solution.InitializeMovingCostsForEveryPosition();
            var minimumMovingCost = solution.CalculateTheMinimumMovingCost();
            
            Console.WriteLine("Minimum moving fuel cost for task 1 is {0}", minimumMovingCost);
            // // // 349812
            //
            
            Console.WriteLine("Solving task 2!");
            solution.InitializePositions();
            solution.InitializeMovingCostsForEveryPosition(usingConstantRateBetweenPositions:false);
            minimumMovingCost = solution.CalculateTheMinimumMovingCost();
            
            Console.WriteLine("Minimum moving fuel cost for task 2 is {0}", minimumMovingCost);
            // // // 99763899
        }
    }
}