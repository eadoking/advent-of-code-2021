using System;
using System.Collections.Generic;
using AdventOfCode.Helpers;
using NUnit.Framework;

namespace AdventOfCode.Day05
{
    public class UnitTests
    {
        private Solution _solution;

        [SetUp]
        public void Setup()
        {
        }

        private void Initialize(string inputFile,bool horizontalAndVerticalOnly = true)
        {
            _solution = new Solution(inputFile);
            var lines = new InputReader(Solution.InputFile).ReadFileAsLines();
            _solution.FillTheGrid(lines, horizontalAndVerticalOnly);
        }


        [Test]
        [TestCase("TestParseSinglePoint")]
        public void TestParseSinglePoint(string pointString)
        {
            Assert.AreEqual((0, 9), Solution.ParseSinglePoint("0,9"));
            ;
            Assert.AreEqual((3, 2), Solution.ParseSinglePoint("3,2"));
            ;
            Assert.AreEqual((0, 0), Solution.ParseSinglePoint("0,0"));
            ;
        }

        [Test]
        [TestCase("TestParseLine")]
        public void TestParseLine(string lineString)
        {
            Assert.AreEqual(((1, 1), (1, 3)), Solution.ParseLine("1,1 -> 1,3"));
            Assert.AreEqual(((9, 7), (7, 7)), Solution.ParseLine("9,7 -> 7,7"));
        }

        [Test]
        [TestCase("TestGridGetLinePointsBetweenTwoPointsWithHorizontalAndVerticalOnly")]
        public void TestGridGetLinePointsBetweenTwoPointsWithHorizontalAndVerticalOnly(string lineString)
        {
            var line = Solution.ParseLine("1,1 -> 1,3");

            Assert.AreEqual((new[]
            {
                (1, 1),
                (1, 2),
                (1, 3)
            }), Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, true));


            line = Solution.ParseLine("9,7 -> 7,7");
            Assert.AreEqual((new[]
            {
                (7, 7),
                (8, 7),
                (9, 7)
            }), Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, true));


            line = Solution.ParseLine("5,7 -> 7,5");
            Assert.IsEmpty(Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, true));
        }

        [Test]
        [TestCase("TestGridGetLinePointsBetweenTwoPointsWithHorizontalAndVerticalOnly")]
        public void TestGridGetLinePointsBetweenTwoPoints(string lineString)
        {
            var line = Solution.ParseLine("1,1 -> 3,3");

            Assert.AreEqual((new[]
            {
                (1, 1),
                (2, 2),
                (3, 3)
            }), Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, false));


            line = Solution.ParseLine("6,4 -> 2,0");
            Assert.AreEqual((new[]
            {
                (2, 0),
                (3, 1),
                (4, 2),
                (5, 3),
                (6, 4)
            }), Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, false));

            line = Solution.ParseLine("9,7 -> 7,7");
            Assert.AreEqual((new[]
            {
                (7, 7),
                (8, 7),
                (9, 7)
            }), Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, false));


            line = Solution.ParseLine("5,7 -> 7,5");
            Assert.AreEqual((new[]
            {
                (5, 7),
                (6, 6),
                (7, 5)
            }), Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, false));

            line = Solution.ParseLine("9,7 -> 7,9");
            Assert.AreEqual((new[]
            {
                (7, 9),
                (8, 8),
                (9, 7)
            }), Grid.GetLinePointsBetweenTwoPoints(line.startPoint, line.endPoint, false));
        }

        [Test]
        [TestCase("INPUT_TEST", true, ExpectedResult = 5)]
        [TestCase("INPUT_TEST",false, ExpectedResult = 12)]
        public int TestCalculateOverlappingPoints(string inputFile, bool horizontalAndVerticalOnly)
        {
            Initialize(inputFile, horizontalAndVerticalOnly);
            return _solution.CalculateOverlappingPoints();
        }
    }
}