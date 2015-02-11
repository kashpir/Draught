using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Square : IVector
    {
        readonly int firstCoordinate;
        readonly int secondCoordinate;

        public int FirstCoordinate { get { return firstCoordinate; } }
        public int SecondCoordinate { get { return secondCoordinate; } }

        public Square() { }

        public Square(string line)
        {
            firstCoordinate = line[0] - Constants.CODE_OF_a + 1;
            secondCoordinate = line[1] - Constants.CODE_OF_0;
        }

        public Square(int firstCoordinate, int secondCoordinate)
        {
            this.firstCoordinate = firstCoordinate;
            this.secondCoordinate = secondCoordinate;
        }

        public StringBuilder CoordinatesToUser()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Convert.ToChar(FirstCoordinate + Constants.CODE_OF_a - 1));
            str.Append(SecondCoordinate);
            return str;
        }

        public bool AreEqual(IVector compared)
        {
            return ((compared.FirstNumber == FirstCoordinate) &&
                    (compared.SecondNumber == SecondCoordinate));
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
