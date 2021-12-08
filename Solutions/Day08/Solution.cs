using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using AdventOfCode.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode.Day08
{
    internal class Solution
    {
        public static string InputFile;
        
        private string[] _lines;
        public Solution(string inputFile = "INPUT")
        {
            InputFile = inputFile;
        }

        private static (string[] decoderTestInput, string[] output) ParseSingleLine(string line)
        { 
            var parts = line.Split('|');
            return (
                decoderTestInput: parts[0].Split(' ', options: StringSplitOptions.RemoveEmptyEntries),
                output: parts[1].Split(' ', options: StringSplitOptions.RemoveEmptyEntries)
            );
        }

        public static Dictionary<char, char> GenerateDecoderMap(string[] decoderTestInputNumbers)
        {
            // ReSharper disable once InvalidXmlDocComment
            /**
                 aaaa
                b    c
                b    c
                 dddd
                e    f
                e    f
                 gggg
             */
            var map = new Dictionary<char, char>();
            // initiate the dictionary with original mapping
            for (var ch ='a'; ch <= 'g'; ch++)
            {
                map[ch] = ch;
            }
            
            // try to generate the new mapping
            // get ones charset: two characters 
            // possible mapping for [c and f]
            var _1_CharSet = decoderTestInputNumbers.Single(value => value.Length == 2).ToCharArray();
            
            // get seven charset: three characters
            var _7_CharSet = decoderTestInputNumbers.Single(value => value.Length == 3).ToCharArray();
            
            // get four charset: four characters
            var _4_CharSet = decoderTestInputNumbers.Single(value => value.Length == 4).ToCharArray();
            
            // get eight charset: all 7 characters
            var _8_CharSet = decoderTestInputNumbers.Single(value => value.Length == 7).ToCharArray();

            map['a'] = _7_CharSet.Except(_1_CharSet).First();
            
            var _3_CharSet = decoderTestInputNumbers.Where(value => value.Length == 5).ToList().Select(element => element.ToCharArray()).First(characters => characters.Except(_1_CharSet).Count() == 3);
          
            // find b  
            map['b']  = _4_CharSet.Except(_3_CharSet).First();

            // find e
            map['d'] = _4_CharSet.Except(_1_CharSet).Except(new []{map['b']}).First();
            
            // find e
            map['e'] = _8_CharSet.Except(_3_CharSet).Except(new []{map['b']}).First();
            
            // find g
            map['g'] = _3_CharSet.Except(_1_CharSet).Except(new []{map['a'], map['d']}).First();
           
            // find f
            
            // different between 6 and 1, is 5
            // different between 0,9 and 1 is 4
            var _6_CharSet = decoderTestInputNumbers.Where(value => value.Length == 6)
                .Where(element => element.ToCharArray().Except(_1_CharSet).Count() == 5).Select(element => element.ToCharArray()).First();
           
            // find c 
            map['c'] = _1_CharSet.Except(_6_CharSet).First();
            
            // find f
            map['f'] = _1_CharSet.Except(new[] {map['c']}).First();
            
            return map;
        }

        private static int PossibleNumber(Dictionary<char, char> map, string combination, bool uniqueOnly = true)
        {
            
            if (!uniqueOnly)
            {
                switch (combination.Length)
                {
                    case 5: // length of 5 is (2, 3, or 5)
                    {
                        // 2 contains a c d e g
                        // 3 contains a c d f g 
                        // 5 contains a b d f g 

                        // the three unique combo is 
                        // 2 -> c e
                        // 3 -> c f
                        // 5 -> b f
                        
                        if (combination.Contains(map['c']))
                        {
                            // 2 and 3
                            return combination.Contains(map['e']) ? 2 : 3;
                        }
                        return 5;
                    }

                    case 6:
                        //only length of 6 is (0, 6, or 9)
                    {
                        // 0 contains a b c e f g 
                        // 6 contains a b d e f g 
                        // 9 contains a b c d f g 

                        // the three unique combo is 
                        // 0 -> c e
                        // 6 -> d e
                        // 9 -> c d

                        // 0 or 6
                        if (combination.Contains(map['e']))
                        {
                            return combination.Contains(map['c']) ? 0 : 6;
                        }

                        return 9;
                    }
                }
            }

            switch (combination.Length)
            {
                case 2:
                    return 1;
                    
                case 3:
                    return 7;
                    
                case 4:
                    return 4;
                    
                case 7:
                    return 8;
            }

            return -1;
        }

        public static int[] PossibleNumbersInLine(string line, bool uniqueOnly = true)
        {
            var parsedLine = ParseSingleLine(line);
            return parsedLine.output.Select(outputNumbers => PossibleNumber(GenerateDecoderMap(parsedLine.decoderTestInput), outputNumbers, uniqueOnly)).Where(number => number!=-1).ToArray();
        }
        
        public static int PossibleNumberInLine(string line)
        {
            return int.Parse(string.Join("", PossibleNumbersInLine(line, false)));
        }

        private void InitializeLines()
        {
            _lines = new InputReader(InputFile).ReadFileAsLines().ToArray();
        }


        public int CalculateCombinations(bool uniqueOnly)
        {
            InitializeLines();
            return _lines.Select(line => PossibleNumbersInLine(line, uniqueOnly)).Select(arr => arr.Length).Sum();
        }
        
        public int CalculateSum()
        {
            InitializeLines();
            return  _lines.Select(PossibleNumberInLine).Sum();
        }
    }
}