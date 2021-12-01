using NUnit.Framework;

namespace AdventOfCode.Day01
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263}, ExpectedResult = 7)]
        public int TestCalculateMeasurements(int[] numbers)
        {
            return Solution.CalculateMeasurements(numbers);
        }

        [TestCase(
            new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263},
            ExpectedResult = new[] {607, 618, 618, 617, 647, 716, 769, 792})]
        public int[] TestConvertNumberArrayIntoSlidingWindowArray(int[] numbers)
        {
            return Solution.ConvertNumberArrayIntoSlidingWindowArray(numbers);
        }

        [TestCase(new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263}, ExpectedResult = 5)]
        public int TestCalculateMeasurementsWithSlidingWindow(int[] numbers)
        {
            return Solution.CalculateMeasurementsWithSlidingWindow(numbers);
        }
    }
}