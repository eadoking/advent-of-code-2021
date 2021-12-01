using System;

namespace AdventOfCode.Helpers
{
    public class GenericHelper
    {
        public static int[] ConvertStringArrayToIntArray(string[] lines)
        {
            return Array.ConvertAll(lines, int.Parse);
        }
    }
}