using System;
using NUnit.Framework;

namespace AdventOfCode.Day03
{
    public class UnitTests
    {
        private string[] _diagnosticReport;

        [SetUp]
        public void Setup()
        {
            _diagnosticReport = new[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
        }

        [TestCase(ExpectedResult = "10110")]
        public string TestCalculateGamma()
        {
            return Solution.CalculateGammaRateBinary(_diagnosticReport);
        }

        [TestCase(ExpectedResult = "01001")]
        public string TestCalculateEpsilon()
        {
            return Solution.CalculateEpsilonBinary(_diagnosticReport);
        }

        [TestCase(ExpectedResult = 198)]
        public int TestCalculatePowerConsumption()
        {
            return Solution.CalculatePowerConsumption(_diagnosticReport);
        }


        [TestCase(ExpectedResult = "10111")]
        public string TestCalculateOxygenGeneratorRatingBinary()
        {
            return Solution.CalculateOxygenGeneratorRatingBinary(_diagnosticReport);
        }

        [TestCase(ExpectedResult = "01010")]
        public string TestCalculateCo2ScrubberRatingBinary()
        {
            return Solution.CalculateCo2ScrubberRatingBinary(_diagnosticReport);
        }

        [TestCase(ExpectedResult = 230)]
        public int TestCalculateLifeSupportRating()
        {
            return Solution.CalculateLifeSupportRating(_diagnosticReport);
        }
    }
}