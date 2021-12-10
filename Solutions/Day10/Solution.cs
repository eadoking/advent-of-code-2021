using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;
using NUnit.Framework;
namespace AdventOfCode.Day10
{
    public class Solution
    {
        public enum LineStatus
        {
            Complete,
            Incomplete,
            Corrupt
        }
        public static string InputFile;

        private List<string> _lines = new List<string>();
        public Solution(string inputFile = "INPUT")
        {
            InputFile = inputFile;
            InitializeLines();
        }
        
        private void InitializeLines()
        {
            _lines = new InputReader(InputFile).ReadFileAsLines().ToList();
        }


        public static (LineStatus status, char current, string autoComplete) CheckLineStatus(string line)
        {
            var characters = line.ToCharArray();
            var stack = new Stack<char>();
            stack.Push(characters[0]);
            
            for (var i = 1; i < characters.Length; i++)
            {
                if (new[] {'{', '[', '(', '<'}.Contains(characters[i]))
                {
                    // open characters add to the stack
                    stack.Push(characters[i]);
                }
                else
                {
                    var stackTop = stack.Peek();
                    var currentChar = characters[i];
                    if (
                        (currentChar == '}' && stackTop == '{') ||
                        (currentChar == ']' && stackTop == '[') || 
                        (currentChar == ')' && stackTop == '(') ||
                        (currentChar == '>' && stackTop == '<')
                        )
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return (status: LineStatus.Corrupt, current:currentChar, autoComplete:"");
                    }
                }
            }
            
            // finding the autocomplete string
            if (stack.Count == 0)
            {
                return (status: LineStatus.Complete, current: '.', autoComplete: "");
            }

            var autoCompleteCharacters = new List<char>();
            var lastIncompleteChar = stack.Peek();
            do
            {
                switch (stack.Pop())
                {
                    case '{':
                        autoCompleteCharacters.Add('}');
                        break;
                    case '(':
                        autoCompleteCharacters.Add(')');
                        break;
                    case '<':
                        autoCompleteCharacters.Add('>');
                        break;
                    case '[':
                        autoCompleteCharacters.Add(']');
                        break;
                }

            } while (stack.Count > 0);
            return  (status: LineStatus.Incomplete, current:lastIncompleteChar, autoComplete : string.Join("", autoCompleteCharacters));
        }


        public static long CalculateSingleAutoCompleteStringScore(string autoComplete)
        {
            var points = new Dictionary<char, long>()
            {
                {')', 1},
                {']', 2},
                {'}', 3},
                {'>', 4},
            };
            return autoComplete.ToCharArray().Select(ch => points[ch]).Aggregate(( score,  acc) => score * 5 + acc);
        }
        public long CalculateSyntaxErrorScore()
        {
            var firstIllegalCharacters = _lines.Select(CheckLineStatus)
                .Where(line => line.status == LineStatus.Corrupt)
                .Select(status => status.current).ToList();
            var points = new Dictionary<char, int>()
            {
                {')', 3},
                {']', 57},
                {'}', 1197},
                {'>', 25137},
            };
            
            // return firstIllegalCharacters.OrderBy(ch => ch).GroupB
            return (from character in firstIllegalCharacters
                orderby character ascending
                group character by character
                into grp
                select points[grp.Key]*grp.Count()).Sum();
        }
        public long CalculateMiddleScore()
        {
            var sortedScore = _lines
                .Select(CheckLineStatus)
                .Where(lineStatus => lineStatus.status == LineStatus.Incomplete)
                .Select(lineStatus => lineStatus.autoComplete)
                .Select(CalculateSingleAutoCompleteStringScore).OrderBy(score => score).ToList();
                
            return sortedScore[(sortedScore.Count -1)  / 2];
        }
    }
    
}