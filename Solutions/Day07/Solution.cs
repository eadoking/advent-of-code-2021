using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day07
{
    internal class Solution
    {
        public static string InputFile;
        // position -> cost
        private readonly Dictionary<int, int> _cost ;//
        
        private int[] _positions;
        public Solution(string inputFile = "INPUT")
        {
            InputFile = inputFile;
            _cost = new Dictionary<int, int>();
        }

        public void InitializePositions()
        {
            _positions = new InputReader(InputFile).ReadFileAsOneString().Split(",").Select(int.Parse).ToArray();
        }
        
        public void InitializeMovingCostsForEveryPosition(bool usingConstantRateBetweenPositions = true)
        {
            var min = _positions.Min();
            var max = _positions.Max();

            for (var position = max; position >= min; position--)
            {
                _cost[position] = CalculateTheCostOfMovingElementsToPosition(position, usingConstantRateBetweenPositions);
            }
        }
        public int CalculateTheCostOfMovingElementsToPosition(int position, bool usingConstantRateBetweenPositions = true)
        {
            return _positions.Select(element =>
            {
                var diff = Math.Abs(element - position);
                return usingConstantRateBetweenPositions ? diff : (diff * (diff + 1) / 2);
            }).Sum();
        }


        public void Print()
        {
            Console.WriteLine("Pos\t\t Cost");
            foreach (var kvp in _cost)
            {
                Console.WriteLine("{0}\t\t\t\t{1}",kvp.Key, kvp.Value);
            }
        }
        
        public int CalculateThePositionMinimumMovingCost()
        {
            // https://stackoverflow.com/a/2806074/10757244
           return _cost.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
        }
        
        public int CalculateTheMinimumMovingCost()
        {
            return _cost[CalculateThePositionMinimumMovingCost()];
        }
    }
}