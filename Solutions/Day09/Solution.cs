using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using AdventOfCode.Helpers;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCode.Day09
{
    internal class Solution
    {
        public static string InputFile;
        private int rows;
        private int cols;

        private (int Value, bool LowPoint, int BasinSize)[,] _map;
        private List<int> _basins = new List<int>();
        public Solution(string inputFile = "INPUT")
        {
            InputFile = inputFile;
            
        }

        private int[] ParseLineIntoNumbers(string line)
        {
           return line.ToCharArray().Select(ch => ch -'0').ToArray();
            // Console.WriteLine("Line  => {0}", line);
            // Console.WriteLine("LineA => {0}", string.Join(",", lineArray));
            // Console.WriteLine("sum => {0}", lineArray.Sum());
            // return Array.Empty<int>();
        }

        public void InitializeMap()
        {
           var line= new InputReader(InputFile).ReadFileAsLines().ToArray();
           rows = line.Length; 
           cols = ParseLineIntoNumbers(line[0]).Length;
           
           _map = new (int Value, bool LowPoint, int BasinSize)[rows,cols];
           
           // Console.WriteLine("rows {0}", rows);
           // Console.WriteLine("cols {0}", cols);
           for (var row = 0; row < rows; row++)
           {
               // Console.Write("Row {0}: ", row);
               var parsedLine = ParseLineIntoNumbers(line[row]);
               for (var col = 0; col < cols; col++)
               {
                   // Console.Write("[{0},{1}]={2},", row, col, parsedLine[col]);
                   
                   _map[row, col] = (Value: parsedLine[col], LowPoint: false, BasinSize:0);
               }
               
               // Console.WriteLine();
           }
        }

        private bool IsValidIndexValue(int row, int col)
        {
            return (row >= 0 && row < rows) && (col >= 0 && col < cols);
        }

        private (int row, int col)[] GetNeighbours(int row, int col)
        {
            return new (int row, int col)[] {
                // (row, col),
                (row: row, col: col + 1),
                (row: row, col: col - 1),

                (row: row + 1, col: col),
                // (row: row + 1, col: col + 1),
                // (row: row + 1, col: col - 1),

                (row: row - 1, col: col),
                // (row: row - 1, col: col + 1),
                // (row: row - 1, col: col - 1)

            }.Where(neighbour => IsValidIndexValue(neighbour.row, neighbour.col)).ToArray();
        }

        public int[] FindBasins(int row, int col)
        {
            if (!_map[row, col].LowPoint)
            {
                return Array.Empty<int>();
            }

            var currentBasinCore = _map[row, col].Value;
            var basins = new List<(int row, int col, int val)> {(row, col, currentBasinCore)};

            var stop = false;
            var runningNeighbours = GetRunningNeighbours(row, col, currentBasinCore);
            do
            {
                var tmpList = new List<(int row, int col, int val)>();
                foreach (var runningNeighbour in runningNeighbours)
                {
                    basins.Add(runningNeighbour);
                    var newNeighbours =
                        GetRunningNeighbours(runningNeighbour.row, runningNeighbour.col, runningNeighbour.val);
                    tmpList.AddRange(newNeighbours);
                }


                runningNeighbours = tmpList.Except(basins).ToList();
                stop = !runningNeighbours.Any();
            } while (!stop);

            List<(int row, int col, int val)> GetRunningNeighbours(int row, int col, int value)
            {
                return GetNeighbours(row, col)
                    .Select(pos => (row: pos.row, col: pos.col, val: _map[pos.row, pos.col].Value))
                    .Where(neighbour => neighbour.val >= value && neighbour.val < 9).ToList();
            }

            return basins.Select(basinPosition => _map[basinPosition.row, basinPosition.col].Value).ToArray();
        }
        private bool IsThePointLowestInArea(int row, int col)
        {
            
            var neighbours = GetNeighbours(row, col).Select(index => _map[index.row, index.col].Value ).ToArray();
            
            foreach (var neighbour in neighbours)
            {
                if (_map[row, col].Value >= neighbour)
                {
                   return false;
                }
            }
            return true;
        }

        public void CalculateLowePoints()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    _map[row, col].LowPoint = IsThePointLowestInArea(row, col);
                    if (_map[row, col].LowPoint)
                    {
                        // point 
                        var basinSize = FindBasins(row, col).Length;
                        _map[row, col].BasinSize = basinSize;
                        _basins.Add(basinSize);
                        // Console.WriteLine("point ({0}, {1})={2} is lower point in area and basin size is {3}",row,col,_map[row,col],basinSize );
                    }
                }
            }
        }

        public int[] GetLowerPoints()
        {
            InitializeMap();
            CalculateLowePoints();
            var lowerPoints = new List<int>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (_map[row, col].LowPoint)
                    {
                        lowerPoints.Add(_map[row, col].Value);
                    }
                }
            }

            return lowerPoints.ToArray();
        }

        public int GetRiskLevel()
        {
            var points = GetLowerPoints();
            return points.Sum() + points.Length;
        }
        
        public int CalculateLargestThreeBasins()
        {
            InitializeMap();
            CalculateLowePoints();
            return (from basin in _basins
                orderby basin descending
                select basin).Take(3).Aggregate((basinValue, acc) => basinValue * acc);
        }

    }
}