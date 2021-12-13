using System;
using System.Collections.Generic;
using System.Linq;using AdventOfCode.Day11;
using AdventOfCode.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static AdventOfCode.Day11.Solution;

namespace AdventOfCode.Day11
{
    public class UnitTests
    {
        // private Solution _solution;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            // _solution = new Solution("INPUT_TEST");
        }
        //
        // [Test]
        // [TestCase("()", ExpectedResult = LineStatus.Complete)]
        // [TestCase("[]", ExpectedResult = LineStatus.Complete)]
        // [TestCase("([])", ExpectedResult = LineStatus.Complete)]
        // [TestCase("{()()()}", ExpectedResult = LineStatus.Complete)]
        // [TestCase("<([{}])>", ExpectedResult = LineStatus.Complete)]
        // [TestCase("[<>({}){}[([])<>]]", ExpectedResult = LineStatus.Complete)]
        // [TestCase("(((((((((())))))))))", ExpectedResult = LineStatus.Complete)]
        // [TestCase("(]", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("{()()()>", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("(((()))}", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("<([]){()}[{}])", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("{([(<{}[<>[]}>{[]{[(<()>", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("[[<[([]))<([[{}[[()]]]", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("[{[{({}]{}}([{[{{{}}([]", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("[<(<(<(<{}))><([]([]()", ExpectedResult = LineStatus.Corrupt)]
        // [TestCase("<{([([[(<>()){}]>(<<{{", ExpectedResult = LineStatus.Corrupt)]
        //
        // [TestCase("[({(<(())[]>[[{[]{<()<>>", ExpectedResult = LineStatus.Incomplete)]
        // [TestCase("[(()[<>])]({[<{<<[]>>(", ExpectedResult = LineStatus.Incomplete)]
        // [TestCase("(((({<>}<{<{<>}{[]{[]{}", ExpectedResult = LineStatus.Incomplete)]
        // [TestCase("{<[[]]>}<{[{[{[]{()[[[]", ExpectedResult = LineStatus.Incomplete)]
        // [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", ExpectedResult = LineStatus.Incomplete)]
        // public LineStatus TestCheckLineStatus(string line)
        // {
        //     return CheckLineStatus(line).status;
        // }
        //
        //
        // [TestCase("(]", ExpectedResult = ']')]
        // [TestCase("{()()()>", ExpectedResult = '>')]
        // [TestCase("(((()))}", ExpectedResult = '}')]
        // [TestCase("<([]){()}[{}])", ExpectedResult = ')')]
        // [TestCase("{([(<{}[<>[]}>{[]{[(<()>", ExpectedResult = '}')]
        // [TestCase("[[<[([]))<([[{}[[()]]]", ExpectedResult = ')')]
        // [TestCase("[{[{({}]{}}([{[{{{}}([]", ExpectedResult = ']')]
        // [TestCase("[<(<(<(<{}))><([]([]()", ExpectedResult = ')')]
        // [TestCase("<{([([[(<>()){}]>(<<{{", ExpectedResult = '>')]
        // public char TestCheckLineStatusWrongCharacter(string line)
        // {
        //     return CheckLineStatus(line).current;
        // }
        //
        //
        // [Test]
        // [TestCase( ExpectedResult = 26397)]
        // public long TestCalculateSyntaxErrorScore()
        // {
        //     return _solution.CalculateSyntaxErrorScore();
        // }
        //
        // [TestCase("[({(<(())[]>[[{[]{<()<>>", ExpectedResult = "}}]])})]")]
        // [TestCase("[(()[<>])]({[<{<<[]>>(", ExpectedResult = ")}>]})")]
        // [TestCase("(((({<>}<{<{<>}{[]{[]{}", ExpectedResult = "}}>}>))))")]
        // [TestCase("{<[[]]>}<{[{[{[]{()[[[]", ExpectedResult = "]]}}]}]}>")]
        // [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", ExpectedResult = "])}>")]
        // public string TestCheckLineIncompleteAutoComplete(string line)
        // {
        //     return CheckLineStatus(line).autoComplete;
        // } 
        //
        // [TestCase("}}]])})]", ExpectedResult = 288957)]
        // [TestCase( ")}>]})", ExpectedResult = 5566)]
        // [TestCase( "}}>}>))))", ExpectedResult = 1480781)]
        // [TestCase("]]}}]}]}>", ExpectedResult = 995444)]
        // [TestCase("])}>", ExpectedResult = 294)]
        // public long TestCalculateSingleAutoCompleteStringScore(string autoComplete)
        // {
        //     return CalculateSingleAutoCompleteStringScore(autoComplete);
        // }
        //
        [Test]
        [TestCase("INPUT_TEST_PARTIAL",1,5, ExpectedResult = 9)]
        [TestCase("INPUT_TEST_PARTIAL",2,5, ExpectedResult = 9)]
        [TestCase("INPUT_TEST",1,10, ExpectedResult = 0)]
        [TestCase("INPUT_TEST",2,10, ExpectedResult = 35)]
        [TestCase("INPUT_TEST",3,10, ExpectedResult = 80)]
        [TestCase("INPUT_TEST",4,10, ExpectedResult = 96)]
        [TestCase("INPUT_TEST",5,10, ExpectedResult = 104)]
        [TestCase("INPUT_TEST",6,10, ExpectedResult = 105)]
        [TestCase("INPUT_TEST",7,10, ExpectedResult = 112)]
        [TestCase("INPUT_TEST",8,10, ExpectedResult = 136)]
        [TestCase("INPUT_TEST",9,10, ExpectedResult = 175)]
        [TestCase("INPUT_TEST",10,10, ExpectedResult = 204)]
        [TestCase("INPUT_TEST",100,10, ExpectedResult = 1656)]
        public long TestCalculateFlashesAfter(string inputFile, int steps, int gridSize)
        {
            var solution = new Solution(inputFile, gridSize);
            return solution.CalculateFlashesAfter(steps);
        }
        
        [TestCase("INPUT_TEST", ExpectedResult = 195)]
      
        public long TestCalculateFirstSyncPoint(string inputFile)
        {
            var solution = new Solution(inputFile);
            return solution.CalculateFirstSyncPoint();
        }

    }
}