using System;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day06
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Solving task 1!");
            var solution = new Solution();
            var initialState = new InputReader(Solution.InputFile).ReadFileAsOneString().Split(",").Select(int.Parse).ToArray();
            solution.InitializeSimulation(initialState);
            solution.SimulateGrowthAfter(80);
            var fishCount = solution.CalculateFishCount();
           
            Console.WriteLine("Fish count for task 1 is {0}", fishCount);
            // // 362346
            
            Console.WriteLine("Solving task 2!");
            // already done 80 days, so faster to continue
            solution.SimulateGrowthAfter(256-80);
            fishCount = solution.CalculateFishCount();
            
            Console.WriteLine("Fish count for task 2 is {0}", fishCount);
            // // 1639643057051
            
        }
    }
}