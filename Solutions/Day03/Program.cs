using System;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day03
{
    public static class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Solving task 1!");
            var diagnosticReport = new InputReader(Solution.InputFile).ReadFileAsLines();
            var powerConsumption = Solution.CalculatePowerConsumption(diagnosticReport);
            Console.WriteLine("Power consumption value for task 1 is {0}", powerConsumption);
            // 2967914
            
            Console.WriteLine("Solving task 2!");
             diagnosticReport = new InputReader(Solution.InputFile).ReadFileAsLines();
            var lifeSupportRating = Solution.CalculateLifeSupportRating(diagnosticReport);
            Console.WriteLine("Life support rating value for task 2 is {0}", lifeSupportRating);
            //7041258
        }
    }
}