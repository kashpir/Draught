using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BusinessLogic
{
    public class BoardGeometry
    {
        public const int DRAUGHT_BOARD_WIDTH = 8;
        public const int DRAUGHT_BOARD_LENGTH = 8;

        private Limits Board { get; set; }
        
        public BoardGeometry()
        {
            Board = new Limits(DRAUGHT_BOARD_WIDTH, DRAUGHT_BOARD_LENGTH);
        }

        public Square ShiftSquare(IVector initialSquare, IVector shift)
        {
            var realshift = new Vector(shift);
            var vector = realshift.Add(initialSquare);
            return new Square(vector.FirstNumber, vector.SecondNumber);
        }
        
        public bool ValidSquare(IVector square)
        {
            return (PlayableSquare(square) && Board.InLimit(square));
        }

        private bool PlayableSquare(IVector square)
        {
            return ((square.FirstNumber + square.SecondNumber) % 2 == 0);
        }
    }
}
