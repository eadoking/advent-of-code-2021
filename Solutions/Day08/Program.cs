using System;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day08
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            var uniqueCombinations = solution.CalculateCombinations(uniqueOnly:true);
            
            Console.WriteLine("Unique combinations for task 1 is {0}", uniqueCombinations);
            // // // // 456
            // //
            //
            Console.WriteLine("Solving task 2!");
            solution = new Solution();
            var sum = solution.CalculateSum();
            //
            Console.WriteLine("sum for task 2 is {0}", sum);
            // // // // 1091609
        }
    }
}