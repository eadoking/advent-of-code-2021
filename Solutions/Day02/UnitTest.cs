using System;
using NUnit.Framework;

namespace AdventOfCode.Day02
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        // arrays of ExpectedResults [Horizontal, Depth] 
        [TestCase("forward 5", ExpectedResult = new [] {5, 0})]
        [TestCase("down 5", ExpectedResult = new [] {0, 5})]
        [TestCase("forward 8", ExpectedResult = new [] {8, 0})]
        [TestCase("up 3", ExpectedResult = new [] {0, -3})]
        [TestCase("down 8", ExpectedResult = new [] {0, 8})]
        public int[] TestParseSingleInstruction(string instruction)
        {
            var position = Solution.ParseSingleInstruction(instruction);
            return new[] {position.Horizontal, position.Depth};
        }
        
        // arrays of ExpectedResults [Horizontal, Depth] 
        [TestCase("forward 5", ExpectedResult = new [] {105, 100})]
        [TestCase("down 5", ExpectedResult = new [] {100, 105})]
        [TestCase("forward 8", ExpectedResult = new [] {108, 100})]
        [TestCase("up 3", ExpectedResult = new [] {100, 97})]
        [TestCase("down 8", ExpectedResult = new [] {100, 108})]
        public int[] TestParseSingleInstructionWithInitialPosition(string instruction)
        {
            var position = Solution.ParseSingleInstruction(instruction, new Position(){Horizontal = 100, Depth = 100});
            return new[] {position.Horizontal, position.Depth};
        }
        
        // arrays of ExpectedResults [Horizontal, Depth] 
        [TestCase( "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2", ExpectedResult = new [] {15, 10})]
        public int[] TestParseMultipleInstructions(params string[] instructions)
        {
            var position = Solution.ParseMultipleInstructions(instructions);
            return new[] {position.Horizontal, position.Depth};
        }
        
        // arrays of ExpectedResults [Horizontal, Depth, aim] 
        [TestCase( "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2", ExpectedResult = new [] {15, 10, 60})]
        public int[] TestParseMultipleInstructionsWithAimCorrection(params string[] instructions)
        {
            var position = Solution.ParseMultipleInstructions(instructions, true);
            return new[] {position.Horizontal, position.Depth, position.Aim};
        }
        
        [TestCase( "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2", ExpectedResult = 150)]
        public int TestCalculateMultiplicationValue(params string[] instructions)
        {
            return Solution.CalculateMultiplicationValue(instructions);
        }
        
        
        [TestCase( "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2", ExpectedResult = 900)]
        public int TestCalculateMultiplicationValueWithAimCorrection(params string[] instructions)
        {
            return Solution.CalculateMultiplicationValue(instructions, withAimCorrection:true);
        }
    }
}