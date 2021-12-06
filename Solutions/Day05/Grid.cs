using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day05
{
    public class Grid
    {
        private readonly Dictionary<(int x, int y), int> _values = new Dictionary<(int x, int y), int>();

        private static bool HorizontalAndVerticalLinesOnly((int x, int y) p1, (int x, int y) p2) =>
            p1.x == p2.x || p1.y == p2.y;

        public static (int x, int y)[] GetLinePointsBetweenTwoPointHorizontalAndVerticalOnly((int x, int y) startPoint,
            (int x, int y) endPoint)
        {
            var points = new List<(int x, int y)>();
            var minX = Math.Min(startPoint.x, endPoint.x);
            var maxX = Math.Max(startPoint.x, endPoint.x);
            var minY = Math.Min(startPoint.y, endPoint.y);
            var maxY = Math.Max(startPoint.y, endPoint.y);
            var diff = Math.Abs(startPoint.x-endPoint.x);

            if (startPoint.y == endPoint.y)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    points.Add((x: x, y: startPoint.y));
                }
            }

            if (startPoint.x == endPoint.x)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    points.Add((x: startPoint.x, y: y));
                }
            }

            return points.ToArray();
        }

        public static (int x, int y)[] GetLinePointsBetweenTwoPoints((int x, int y) startPoint, (int x, int y) endPoint,
            bool horizontalAndVerticalOnly = true)
        {
            var points = GetLinePointsBetweenTwoPointHorizontalAndVerticalOnly(startPoint, endPoint).ToList();
            if (horizontalAndVerticalOnly)
            {
                return points.ToArray();
            }

            if (HorizontalAndVerticalLinesOnly(startPoint, endPoint))
            {
                points = GetLinePointsBetweenTwoPointHorizontalAndVerticalOnly(startPoint, endPoint).ToList();
                return points.ToArray();
            }
            
            var maxX = Math.Max(startPoint.x, endPoint.x);
            var maxY = Math.Max(startPoint.y, endPoint.y);
            var diff = Math.Abs(startPoint.x-endPoint.x);
            
            if ((startPoint.x - endPoint.x) * (startPoint.y - endPoint.y) > 0)
            {
                for (int i = 0; i <= diff; i++)
                {
                    points.Add((x: maxX-diff +i, y: maxY - diff +i));
                }
            }
            else
            {
                var (baseX, baseY) = startPoint.x > endPoint.x? (endPoint.x, endPoint.y):(startPoint.x, startPoint.y);
                for (int i = 0; i <= diff; i++)
                {
                    points.Add((x:baseX + i , y: baseY - i));
                }
            }

            return points.ToArray();
         
        }

        public void MarkLine((int x, int y) startPoint, (int x, int y) endPoint, bool horizontalAndVerticalOnly = true)
        {
            foreach (var point in GetLinePointsBetweenTwoPoints(startPoint, endPoint, horizontalAndVerticalOnly))
            {
                if (_values.ContainsKey((point.x, point.y)))
                {
                    _values[(point.x, point.y)]++;
                }
                else
                {
                    _values[(point.x, point.y)] = 1;
                }
            }
        }

        public int GetOverlappingPoints()
        {
            return _values.Values.Count(value => value > 1);
        }
    }
}