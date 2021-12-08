using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode.Day08
{
    public class UnitTests
    {
        private Solution _solution;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _solution = new Solution("INPUT_TEST");
            // _solution.InitializeLines();
        }
        
        [Test]
        [TestCase( "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", true, ExpectedResult = new int[] {8, 4})]
        [TestCase( "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", true, ExpectedResult = new int[] {7, 8, 1})]
        [TestCase( "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", true, ExpectedResult = new int[] {1,1,7})]
        public int[] TestPossibleNumbersInLine(string line, bool uniqueOnly)
        {
            return Solution.PossibleNumbersInLine( line, uniqueOnly);
        }
        
        [Test]
        [TestCase( "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", true, ExpectedResult = 8394 )]
        [TestCase( "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", true, ExpectedResult =9781)]
        [TestCase( "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", true, ExpectedResult = 1197)]
        [TestCase( "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb", true, ExpectedResult = 9361)]
        [TestCase( "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea", true, ExpectedResult = 4873)]
        [TestCase( "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb", true, ExpectedResult = 8418)]
        [TestCase( "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe", true, ExpectedResult = 4548)]
        [TestCase( "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef", true, ExpectedResult = 1625)]
        [TestCase( "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb", true, ExpectedResult = 8717)]
        [TestCase( "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce", true, ExpectedResult = 4315)]
        public int TestPossibleNumberInLine(string line, bool uniqueOnly)
        {
            return Solution.PossibleNumberInLine( line);
        }
        
        [Test]
        [TestCase(true, ExpectedResult = 26)]
        public int TestCalculateCombinations(bool uniqueOnly)
        {
            return _solution.CalculateCombinations(uniqueOnly);
        }
        
        [Test]
        [TestCase( "acedgfb","cdfbe", "gcdfa","fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab")]
          
        public void TestGenerateMapping(params string[] testNumbers)
        {
            var expectedMapping = new Dictionary<char, char>();
            expectedMapping.Add('a', 'd');
            expectedMapping.Add('b', 'e');
            expectedMapping.Add('c', 'a');
            expectedMapping.Add('d', 'f');
            expectedMapping.Add('e', 'g');
            expectedMapping.Add('f', 'b');
            expectedMapping.Add('g', 'c');

            var actualMapping = Solution.GenerateDecoderMap(testNumbers);
            Assert.AreEqual(expectedMapping,actualMapping);
        }

        [Test]
        [TestCase(ExpectedResult = 61229)]
        public int TestCalculateSum()
        {
            return _solution.CalculateSum();
        }

    }
}