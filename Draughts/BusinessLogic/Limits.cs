using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Limits
    {
        private const int MinFirstCoordinate = 1;
        private const int MinSecondCoordinate = 1;

        private int Width { get; set; }
        private int Length { get; set; }

        public Limits(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public bool InLimit(IVector square)
        {
            var inLimitFirstCoordinate = (MinFirstCoordinate <= square.FirstNumber &&
                square.FirstNumber <= Width);
            var inLimitSecondCoordinate = (MinSecondCoordinate <= square.SecondNumber &&
                square.SecondNumber <= Length);
            return (inLimitFirstCoordinate && inLimitSecondCoordinate);
        }
    }
}
