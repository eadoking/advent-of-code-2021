using System;
using System.Collections.Generic;
using System.Linq;using AdventOfCode.Day10;
using AdventOfCode.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static AdventOfCode.Day10.Solution;

namespace AdventOfCode.Day10
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
        [TestCase("()", ExpectedResult = LineStatus.Complete)]
        [TestCase("[]", ExpectedResult = LineStatus.Complete)]
        [TestCase("([])", ExpectedResult = LineStatus.Complete)]
        [TestCase("{()()()}", ExpectedResult = LineStatus.Complete)]
        [TestCase("<([{}])>", ExpectedResult = LineStatus.Complete)]
        [TestCase("[<>({}){}[([])<>]]", ExpectedResult = LineStatus.Complete)]
        [TestCase("(((((((((())))))))))", ExpectedResult = LineStatus.Complete)]
        [TestCase("(]", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("{()()()>", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("(((()))}", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("<([]){()}[{}])", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("{([(<{}[<>[]}>{[]{[(<()>", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("[[<[([]))<([[{}[[()]]]", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("[{[{({}]{}}([{[{{{}}([]", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("[<(<(<(<{}))><([]([]()", ExpectedResult = LineStatus.Corrupt)]
        [TestCase("<{([([[(<>()){}]>(<<{{", ExpectedResult = LineStatus.Corrupt)]
        
        [TestCase("[({(<(())[]>[[{[]{<()<>>", ExpectedResult = LineStatus.Incomplete)]
        [TestCase("[(()[<>])]({[<{<<[]>>(", ExpectedResult = LineStatus.Incomplete)]
        [TestCase("(((({<>}<{<{<>}{[]{[]{}", ExpectedResult = LineStatus.Incomplete)]
        [TestCase("{<[[]]>}<{[{[{[]{()[[[]", ExpectedResult = LineStatus.Incomplete)]
        [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", ExpectedResult = LineStatus.Incomplete)]
        public LineStatus TestCheckLineStatus(string line)
        {
            return CheckLineStatus(line).status;
        }
        

        [TestCase("(]", ExpectedResult = ']')]
        [TestCase("{()()()>", ExpectedResult = '>')]
        [TestCase("(((()))}", ExpectedResult = '}')]
        [TestCase("<([]){()}[{}])", ExpectedResult = ')')]
        [TestCase("{([(<{}[<>[]}>{[]{[(<()>", ExpectedResult = '}')]
        [TestCase("[[<[([]))<([[{}[[()]]]", ExpectedResult = ')')]
        [TestCase("[{[{({}]{}}([{[{{{}}([]", ExpectedResult = ']')]
        [TestCase("[<(<(<(<{}))><([]([]()", ExpectedResult = ')')]
        [TestCase("<{([([[(<>()){}]>(<<{{", ExpectedResult = '>')]
        public char TestCheckLineStatusWrongCharacter(string line)
        {
            return CheckLineStatus(line).current;
        }
        
        
        [Test]
        [TestCase( ExpectedResult = 26397)]
        public long TestCalculateSyntaxErrorScore()
        {
            return _solution.CalculateSyntaxErrorScore();
        }
        
        [TestCase("[({(<(())[]>[[{[]{<()<>>", ExpectedResult = "}}]])})]")]
        [TestCase("[(()[<>])]({[<{<<[]>>(", ExpectedResult = ")}>]})")]
        [TestCase("(((({<>}<{<{<>}{[]{[]{}", ExpectedResult = "}}>}>))))")]
        [TestCase("{<[[]]>}<{[{[{[]{()[[[]", ExpectedResult = "]]}}]}]}>")]
        [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", ExpectedResult = "])}>")]
        public string TestCheckLineIncompleteAutoComplete(string line)
        {
            return CheckLineStatus(line).autoComplete;
        } 
        
        [TestCase("}}]])})]", ExpectedResult = 288957)]
        [TestCase( ")}>]})", ExpectedResult = 5566)]
        [TestCase( "}}>}>))))", ExpectedResult = 1480781)]
        [TestCase("]]}}]}]}>", ExpectedResult = 995444)]
        [TestCase("])}>", ExpectedResult = 294)]
        public long TestCalculateSingleAutoCompleteStringScore(string autoComplete)
        {
            return CalculateSingleAutoCompleteStringScore(autoComplete);
        }
        
        [Test]
        [TestCase( ExpectedResult = 288957)]
        public long TestCalculateMiddleScore()
        {
            return _solution.CalculateMiddleScore();
        }
    }
}