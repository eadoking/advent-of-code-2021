using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;
using NUnit.Framework;
namespace AdventOfCode.Day11
{
    public class Solution
    {
        private readonly int _gridSize;
            
        private readonly int[,] _grid;

        private static string InputFile;

        private List<string> _lines = new List<string>();

        public int Flashes { get; private set; } = 0;

        public Solution(string inputFile = "INPUT",int gridSize = 10)
        {
            InputFile = inputFile;
            _gridSize = gridSize;
            InitializeLines();
            _grid = new int[_gridSize, _gridSize];

            InitializeGrid();
        }
        
        private void InitializeLines()
        {
            _lines = new InputReader(InputFile).ReadFileAsLines().ToList();
        }
        private void InitializeGrid()
        {
            for (var row = 0; row < _gridSize; row++)
            {
                var points = _lines[row].ToCharArray().Select(ch => ch - '0').ToArray();
                for (var col = 0; col < _gridSize; col++)
                {
                    _grid[row, col] = points[col];
                }
            }
        }

        public int[,] GetGrid()
        {
            return _grid;
        }

        private bool IsValidIndexValue(int row, int col)
        {
            return (row >= 0 && row < _gridSize) && (col >= 0 && col < _gridSize);
        }
        private (int row, int col)[] GetNeighbours((int row, int col) position)
        {
            var (row, col) = (position.row,   position.col);
            
            return new (int row, int col)[] {
                // vertical
                (row: row, col: col + 1),
                (row: row, col: col - 1),

                // horizontal
                (row: row + 1, col: col),
                (row: row - 1, col: col),
                
                
                // diagonal
                (row: row + 1, col: col + 1),
                (row: row + 1, col: col - 1),

                (row: row - 1, col: col + 1),
                (row: row - 1, col: col - 1)

            }.Where(neighbour => IsValidIndexValue(neighbour.row, neighbour.col)).ToArray();
        }
 
        private void SimulateOneStep()
        {
            var flashPoints = new List<(int row, int col)>();

            for (var row = 0; row < _gridSize; row++)
            {
                for (var col = 0; col < _gridSize; col++)
                {
                    var newValue = IncreaseBy1((row, col));
                    if (newValue > 9)
                    {
                        flashPoints.Add((row, col));
                    }
                }
            }

            if (!flashPoints.Any())
            {
                return;
            }

            var runningFlashPoints = new List<(int row, int col)>();
            runningFlashPoints.AddRange(flashPoints);
            bool stop;
            do
            {
                var tmpList = (
                    from flashPoint in runningFlashPoints from neighbour in GetNeighbours(flashPoint) let newValue = IncreaseBy1(neighbour) where newValue > 9 select neighbour
                    ).Except(flashPoints).ToList();
                
                flashPoints.AddRange(tmpList);

                runningFlashPoints.Clear();
                runningFlashPoints.AddRange(tmpList);
                
                stop = !tmpList.Any();
            } while (!stop);
            
            foreach (var potentialFlash in flashPoints)
            {
                _grid[potentialFlash.row, potentialFlash.col] = 0;
            }
            Flashes +=  flashPoints.Count;
            
            int IncreaseBy1((int row, int col) position)
            {
                return ++_grid[position.row, position.col];
            }
        }
        
        // for debug only
        public void Print()
        {
            for (var row = 0; row < _gridSize; row++)
            {
                for (var col = 0; col < _gridSize; col++)
                {
                    Console.Write("{0}", _grid[row, col]);
                }
                Console.WriteLine();
            }
        }
        public int CalculateFlashesAfter(int steps)
        {
            for (int i = 1; i <= steps; i++)
            {
                SimulateOneStep();
            }

            return Flashes;
        }


        public bool IsAllOctopusesInSync()
        {
            for (int row = 0; row < _gridSize; row++)
            {
                for (int col = 0; col < _gridSize; col++)
                {
                    if (_grid[row, col] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public int CalculateFirstSyncPoint()
        {
            var maxSteps = 1000;
            for (int i = 1; i <= maxSteps; i++)
            {
                SimulateOneStep();
                if (IsAllOctopusesInSync())
                {
                    return i;
                }
            }
            return 0;
        }
    }
    
}