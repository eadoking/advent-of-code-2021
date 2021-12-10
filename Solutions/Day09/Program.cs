using System;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day09
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            var riskLevel = solution.GetRiskLevel();
            
            Console.WriteLine("risk level for task 1 is {0}", riskLevel);
            // // // 591
            // //
            //
            Console.WriteLine("Solving task 2!");
            solution = new Solution();
            var sum = solution.CalculateLargestThreeBasins();
            
            Console.WriteLine("sum for task 2 is {0}", sum);
            // // // 1113424
        }
    }
}