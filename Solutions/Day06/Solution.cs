using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day06
{
    internal class Solution
    {
        public static string InputFile;
        
        private readonly Dictionary<int, long> _fish ;//
        public Solution(string inputFile = "INPUT")
        {
            InputFile = inputFile;
            _fish = new Dictionary<int, long>();
            for (var i = 0; i <= 8; i++)
            {
                _fish[i] = 0;
            }
        }

        public void InitializeSimulation(int[] initialState)
        {
            foreach (var num in initialState)
            {
                _fish[num]++;
            }
        }

        public long CalculateFishCount()
        {
            return _fish.Values.Sum();
        }

        private void SimulateGrowthAfterOneDay()
        {
            var expectedGrowth = _fish[0];
            for (var i = 0; i <= 7; i++)
            {
                _fish[i] = _fish[i + 1];
            }

            _fish[6] += expectedGrowth;
            _fish[8] = expectedGrowth;
        }
        
        public void SimulateGrowthAfter(int days)
        {
            for (int i = 0; i < days; i++)
            {
                SimulateGrowthAfterOneDay();
            }
        }
    }
}