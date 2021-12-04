using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day04
{
    public class Board
    {
        private const int BoardSize = 5;
        private readonly (int Value, bool Checked)[,] _values;
        
        public Board()
        {
            _values = new (int value, bool Checked)[BoardSize, BoardSize];
        }

        public void FillBoard(int[,] values)
        {
            for (var row = 0; row < BoardSize; row++)
            for (var col = 0; col < BoardSize; col++)
                FillCell(row, col, values[row, col]);
        }

        public void FillRow(int row, List<int> vals)
        {
            for (var i = 0; i < BoardSize; i++) FillCell(row, i, vals[i]);
        }

        public void FillCell(int row, int col, int val)
        {
            _values[row, col] = (Value: val, Checked: false);
        }

        public void CheckCell(int number)
        {
            // need to be optimized
            for (var row = 0; row < BoardSize; row++)
            for (var col = 0; col < BoardSize; col++)
                if (_values[row, col].Value == number)
                    _values[row, col].Checked = true;
        }

        public void CheckCell(int row, int col)
        {
            _values[row, col].Checked = true;
        }

        private bool BingoSingleRowOrColumns((int Value, bool Checked)[] elements)
        {
            return elements.Where(e => e.Checked).ToList().Count == BoardSize;
        }

        // for debug
        public void Print()
        {
            for (var row = 0; row < BoardSize; row++)
                Console.WriteLine("{0}",
                    string.Join(" ", GetRow(row).Select(t => string.Concat(t.value, t.Checked ? "*" : ""))));
        }

        private (int value, bool Checked)[] GetRow(int row)
        {
            return ArrayHelper<(int Value, bool Selected)>.GetRow(_values, row);
        }

        private (int value, bool Checked)[] GetCol(int col)
        {
            return ArrayHelper<(int Value, bool Selected)>.GetCol(_values, col);
        }

        public bool Bingo()
        {
            // check rows and columns at the same time
            for (var i = 0; i < BoardSize; i++)
            {
                var row = GetRow(i);
                if (BingoSingleRowOrColumns(row)) return true;

                var col = GetCol(i);
                if (BingoSingleRowOrColumns(col)) return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Board) obj);
        }

        public override int GetHashCode()
        {
            return (_values != null ? _values.GetHashCode() : 0);
        }

        private bool Equals(Board other)
        {
            for (var row = 0; row < BoardSize; row++)
            for (var col = 0; col < BoardSize; col++)
            {
                if (_values[row, col].Value == other._values[row, col].Value &&
                    _values[row, col].Checked == other._values[row, col].Checked) continue;
                return false;
            }
            return true;
        }

        public int SumNoChecked()
        {
            var sum = 0;
            // need to be optimized
            for (var row = 0; row < BoardSize; row++)
            for (var col = 0; col < BoardSize; col++)
                if (!_values[row, col].Checked)
                    sum += _values[row, col].Value;

            return sum;
        }
    }
}