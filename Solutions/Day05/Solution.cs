using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day05
{
    internal class Solution
    {
        public static string InputFile;
        private readonly Grid _grid; 
        public Solution(string inputFile = "INPUT")
        {
            InputFile = inputFile;
            _grid = new Grid();
        }

        public static (int x, int y) ParseSinglePoint(string pointString)
        {
            var point= pointString.Split(",").Select(int.Parse).ToList();
            return (point[0], point[1]);
        }
        
        public static ((int x, int y) startPoint, (int x, int y) endPoint) ParseLine(string lineString)
        {
            var points= lineString.Split(" -> ").ToList().Select(ParseSinglePoint).ToList();
            return (points[0], points[1]);
        }

        public void FillTheGrid(string[] lines, bool horizontalAndVerticalOnly = true)
        {
            foreach (var line in lines)
            {
                var points = ParseLine(line);
                _grid.MarkLine(points.startPoint, points.endPoint, horizontalAndVerticalOnly);  
            }
            
        }
        public int CalculateOverlappingPoints()
        {
            return _grid.GetOverlappingPoints();
        }

    }
}