using System;
using System.Collections.Generic;
using AdventOfCode.Helpers;
using NUnit.Framework;

namespace AdventOfCode.Day06
{
    public class UnitTests
    {
        private Solution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Solution();
        }

        [Test]
        [TestCase(new int[]{3,4,3,1,2}, 18, ExpectedResult = 26)]
        [TestCase(new int[]{3,4,3,1,2}, 80, ExpectedResult = 5934)]
        [TestCase(new int[]{3,4,3,1,2}, 256, ExpectedResult = 26984457539 )]
        public long TestCalculateFishCount(int[] initialState, int days)
        {
            _solution.InitializeSimulation(initialState);
            _solution.SimulateGrowthAfter(days);
            return _solution.CalculateFishCount();
        }
    }
}