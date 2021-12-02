using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day02
{
    internal static class Solution
    {
        public static readonly string InputFile = "INPUT";

        public static Position ParseSingleInstruction(string instruction, Position initialPosition = null)
        {
            var parsedArray = instruction.Split(' ');
            var command = parsedArray[0];
            var value = int.Parse(parsedArray[1]);
            initialPosition ??= new Position() ;
            switch (command)
            {
                case "forward" :
                    initialPosition.Horizontal+=value;
                    if (initialPosition.WithAimCorrection && initialPosition.Depth != 0)
                    {
                        initialPosition.Aim += initialPosition.Depth * value;
                    }
                    break;
                
                case "up":
                    initialPosition.Depth -= value;
                    break;
                    
                case "down":
                    initialPosition.Depth += value;
                    break;
            }

            return initialPosition;
        }
        
        public static Position ParseMultipleInstructions(string[] instructions, bool withAimCorrection = false)
        {
            var position = new Position() {WithAimCorrection = withAimCorrection};
            return instructions.Aggregate(position, (current, instruction) => ParseSingleInstruction(instruction, current));
        }

        public static int CalculateMultiplicationValue(string[] instructions, bool withAimCorrection = false)
        {
            return ParseMultipleInstructions(instructions, withAimCorrection: withAimCorrection).MultiplicationValue();
        }
    
    }
}