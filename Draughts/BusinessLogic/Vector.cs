using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Vector : IVector
    {
        //public IVector Pair { get; set; }
        public int FirstCoordinate { get; set; }
        public int SecondCoordinate { get; set; }
        
        public Vector(IVector vector)
        {
            FirstCoordinate = vector.FirstNumber;
            SecondCoordinate = vector.SecondNumber;
        }

        public Vector(int first, int second)
        {
            FirstCoordinate = first;
            SecondCoordinate = second;
        }

        public bool AreEquare(IVector vector)
        {
            return ((vector.FirstNumber == FirstCoordinate) &&
                    (vector.FirstNumber == SecondCoordinate));
        }

        public Vector Add(IVector vector)
        {
            var first = FirstCoordinate + vector.FirstNumber;
            var second = SecondCoordinate + vector.SecondNumber;
            return new Vector(first, second);
        }

        public Vector Multiple(int number)
        {
            var first = FirstCoordinate * number;
            var second = SecondCoordinate * number;
            return new Vector(first, second);
        }

        public int FirstNumber
        {
            get { return FirstCoordinate; }
        }

        public int SecondNumber
        {
            get { return SecondCoordinate; }
        }
    }
}
