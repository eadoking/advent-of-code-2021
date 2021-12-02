using System;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day02
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            
            Console.WriteLine("Solving task 1!");
            var instructions = new InputReader(Solution.InputFile).ReadFileAsLines();
            var multiplicationValue = Solution.CalculateMultiplicationValue(instructions);
            Console.WriteLine("Multiplication value for task 1 is {0}", multiplicationValue);
            //1484118
            
            Console.WriteLine("===============================================");
            
            Console.WriteLine("Solving task 2!");
             multiplicationValue = Solution.CalculateMultiplicationValue(instructions, withAimCorrection: true);
            Console.WriteLine("Multiplication value for task 2 is {0}", multiplicationValue);
            //1463827010
        }
    }
}