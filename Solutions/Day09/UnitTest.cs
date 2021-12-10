using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode.Day09
{
    public class UnitTests
    {
        private Solution _solution;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _solution = new Solution("INPUT_TEST");
            
        }
        
        [Test]
        [TestCase(ExpectedResult = new int[] {1, 0, 5,5})]
        public int[] TestGetLowerPoints()
        {
            return _solution.GetLowerPoints( );
        }
        
        [Test]
        [TestCase(0,1,ExpectedResult = new int[] {1,2,3})]
        [TestCase(0,9,ExpectedResult = new int[] {0, 1, 1,2, 2, 2,3,4,4})]
        [TestCase(2,2,ExpectedResult = new int[] {5,6,8,6, 8,7,7,7,7,8,8,8,8,8})]
        [TestCase(4,6,ExpectedResult = new int[] {5,6,6,6, 7,7,8,8,8})]
        [TestCase(4,9,ExpectedResult = new int[] {})]
        [TestCase(0,0,ExpectedResult = new int[] {})]
        public int[] FindBasins(int row, int col)
        {
            _solution.InitializeMap();
            _solution.CalculateLowePoints();
            return _solution.FindBasins(row,col );
        }

        
        [Test]
        [TestCase(ExpectedResult = 15)]
        public int TestGetRiskLevel()
        {
            return _solution.GetRiskLevel( );
        }
         [Test]
        [TestCase(ExpectedResult = 1134)]
        public int TestCalculateLargestThreeBasins()
        {
            return _solution.CalculateLargestThreeBasins( );
        }
        

    }
}