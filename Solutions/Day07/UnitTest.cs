using System;
using System.Collections.Generic;
using AdventOfCode.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode.Day07
{
    public class UnitTests
    {
        private Solution _solution;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _solution = new Solution("INPUT_TEST");
            _solution.InitializePositions();
        }
        
        [Test]
        [TestCase(1,true, ExpectedResult = 41)]
        [TestCase( 2,true,  ExpectedResult = 37)]
        [TestCase(3,true,  ExpectedResult = 39)]
        [TestCase( 10,true, ExpectedResult = 71)]
        
        [TestCase( 2,false,  ExpectedResult = 206)]
        [TestCase( 5,false,  ExpectedResult = 168)]

        public long TestCalculateTheCostOfMovingElementsToPosition(int position, bool usingConstantRateBetweenPositions = true)
        {
            return _solution.CalculateTheCostOfMovingElementsToPosition( position, usingConstantRateBetweenPositions);
        }
        
        [Test]
        [TestCase(true,ExpectedResult = 2)]
        [TestCase(false,ExpectedResult = 5)]
        public long TestCalculateThePositionMinimumMovingCost(bool usingConstantRateBetweenPositions = true)
        {
            _solution.InitializeMovingCostsForEveryPosition(usingConstantRateBetweenPositions);
            _solution.Print();
            return _solution.CalculateThePositionMinimumMovingCost();
        }
        
        [Test]
        [TestCase(true, ExpectedResult = 37)]
        [TestCase(false, ExpectedResult = 168)]
        public long TestCalculateTheMinimumMovingCost(bool usingConstantRateBetweenPositions)
        {
            _solution.InitializeMovingCostsForEveryPosition(usingConstantRateBetweenPositions);
            _solution.Print();
            return _solution.CalculateTheMinimumMovingCost( );
        }
        
    }
}