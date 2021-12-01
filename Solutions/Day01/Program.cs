using System;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day01
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            
            Console.WriteLine("Solving task 1!");
            var inputFile = new InputReader(Solution.InputFile).ReadFileAsLines();
            var numbers = GenericHelper.ConvertStringArrayToIntArray(inputFile);
            var measurements = Solution.CalculateMeasurements(numbers);
            Console.WriteLine("Measurements for task 1 is {0}", measurements);
            
            Console.WriteLine("===============================================");
            
            Console.WriteLine("Solving task 2!");
            measurements = Solution.CalculateMeasurementsWithSlidingWindow(numbers);
            Console.WriteLine("Measurements for task 2 is {0}", measurements);
        }
    }
}