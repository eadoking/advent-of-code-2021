using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day01
{
    internal static class Solution
    {
        public static readonly string InputFile = "INPUT";

        public static int CalculateMeasurements(int[] numbers)
        {
            return numbers.Aggregate(new[] {0, int.MaxValue},
                (tmp, current) => new[] {current > tmp[1] ? tmp[0] + 1 : tmp[0], current})[0];
        }

        public static int[] ConvertNumberArrayIntoSlidingWindowArray(int[] numbers)
        {
            int CalculateWindowOfThree(int i)
            {
                return numbers[i] + numbers[i + 1] + numbers[i + 2];
            }

            var l = new List<int>();
            for (var i = 0; i < numbers.Length - 2; i++) l.Add(CalculateWindowOfThree(i));

            return l.ToArray();
        }

        public static int CalculateMeasurementsWithSlidingWindow(int[] numbers)
        {
            return CalculateMeasurements(ConvertNumberArrayIntoSlidingWindowArray(numbers));
        }
    }
}