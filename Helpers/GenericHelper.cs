using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Helpers
{
    public static class GenericHelper
    {
        public static int[] ConvertStringArrayToIntArray(string[] lines)
        {
            return Array.ConvertAll(lines, int.Parse);
        }
        
        // https://stackoverflow.com/questions/355945/find-the-most-occurring-number-in-a-listint
        public static T MostCommon<T>(this IEnumerable<T> list)
        {
            return (from element in list
                group element by element into grp
                orderby grp.Count() descending
                select grp.Key).First();
        }
        
        public static T LeastCommon<T>(this IEnumerable<T> list)
        {
            return (from element in list
                group element by element into grp
                orderby grp.Count() ascending 
                select grp.Key).First();
        }
    }
}