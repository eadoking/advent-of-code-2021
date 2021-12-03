using System;
using NUnit.Framework;

namespace AdventOfCode.Helpers
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase(new [] { 0,1,0,0,0,1,0,1,0,1,0,1 }, ExpectedResult = 0 )]
        public int TestMostCommon(int[] list)
        {
            return list.MostCommon();
        }

        [TestCase(new [] { 0,1,0,0,0,1,0,1,0,1,0,1 }, ExpectedResult = 1 )]
        public int TestLeastCommon(int[] list)
        {
            return list.LeastCommon();
        }
    }
}