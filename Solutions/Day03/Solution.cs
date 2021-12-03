using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day03
{
    internal static class Solution
    {
        public static readonly string InputFile = "INPUT";

        public static string CalculateGammaRateBinary(string[] diagnosticReport)
        {
            var maximumReportWordLength = diagnosticReport[0].Length;
            var gamma = new List<char>();
            var diagnosticReportList = diagnosticReport.ToList();
            for (var i = 0; i < maximumReportWordLength; i++)
            {
                gamma.Add(diagnosticReportList.Select(report => report[i]).MostCommon());
            }

            return string.Join("", gamma);
        }

        public static string CalculateEpsilonBinary(string[] diagnosticReport)
        {
            var gamma = CalculateGammaRateBinary(diagnosticReport);
            return string.Join("", gamma.Select(ch => ch == '0' ? '1' : '0').ToList());
        }

        public static int CalculatePowerConsumption(string[] diagnosticReport)
        {
            var gamma = Convert.ToInt32(CalculateGammaRateBinary(diagnosticReport), 2);
            var epsilon = Convert.ToInt32(CalculateEpsilonBinary(diagnosticReport), 2);
            return gamma * epsilon;
        }


        public static string CalculateOxygenGeneratorRatingBinary(string[] diagnosticReport)
        {
            var maximumReportWordLength = diagnosticReport[0].Length;
            var oxygenRating = new List<char>();
            var diagnosticReportList = diagnosticReport.ToList();
            for (var i = 0; i < maximumReportWordLength; i++)
            {
                if (diagnosticReportList.Count == 1)
                {
                    oxygenRating.Add(diagnosticReportList.ElementAt(0)[i]);
                    continue;
                }

                var mostCommon = diagnosticReportList.Select(report => report[i]).MostCommon();
                var leastCommon = diagnosticReportList.Select(report => report[i]).LeastCommon();

                oxygenRating.Add(mostCommon == leastCommon ? '1' : mostCommon);

                diagnosticReportList = diagnosticReportList.Where(
                    (report => report[i] == mostCommon)).ToList();
            }

            return string.Join("", oxygenRating);
        }

        public static string CalculateCo2ScrubberRatingBinary(string[] diagnosticReport)
        {
            var maximumReportWordLength = diagnosticReport[0].Length;
            var co2Rating = new List<char>();
            var diagnosticReportList = diagnosticReport.ToList();
            for (var i = 0; i < maximumReportWordLength; i++)
            {
                if (diagnosticReportList.Count == 1)
                {
                    co2Rating.Add(diagnosticReportList.ElementAt(0)[i]);
                    continue;
                }

                var mostCommon = diagnosticReportList.Select(report => report[i]).MostCommon();
                var leastCommon = diagnosticReportList.Select(report => report[i]).LeastCommon();

                var characterToAdd = leastCommon == mostCommon ? '0' : leastCommon;
                co2Rating.Add(characterToAdd);


                diagnosticReportList = diagnosticReportList.Where(
                    (report => report[i] == characterToAdd)).ToList();
            }

            return string.Join("", co2Rating);
        }

        public static int CalculateLifeSupportRating(string[] diagnosticReport)
        {
            var o2 = Convert.ToInt32(CalculateOxygenGeneratorRatingBinary(diagnosticReport), 2);
            var co2 = Convert.ToInt32(CalculateCo2ScrubberRatingBinary(diagnosticReport), 2);
            return o2 * co2;
        }
    }
}