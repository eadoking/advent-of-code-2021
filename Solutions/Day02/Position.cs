using System;

namespace AdventOfCode.Day02
{
    public class Position
    {
        public bool WithAimCorrection { get; set; }
        public int Horizontal { get; set; }
        public int Depth { get; set; }
        
        public int Aim { get; set; }

        public Position()
        {
            Horizontal = 0;
            Depth = 0;
            Aim = 0;
            WithAimCorrection = false;
        }

        public int MultiplicationValue() => WithAimCorrection? Horizontal* Aim: Horizontal * Depth;
    }
}