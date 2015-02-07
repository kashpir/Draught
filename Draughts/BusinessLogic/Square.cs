using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Square : IToUser, ICreate
    {
        private const int LowLimit = 1;
        private const int UpperLimit = 8;

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

        public bool OnBoard()
        {
            return (OnRightSquares() && InLimit(FirstCoordinate) &&
                    InLimit(SecondCoordinate));
        }

        public bool AreEqual(Square compared)
        {
            return ((compared.FirstCoordinate == FirstCoordinate) &&
                    (compared.SecondCoordinate == SecondCoordinate));
        }

        public Square CreateSquare(Geometry.Direction direction, int distance)
        {
            switch (direction)
            {
                case Geometry.Direction.LeftUp:
                    return new Square(FirstCoordinate - distance, SecondCoordinate + distance);
                case Geometry.Direction.RightUp:
                    return new Square(FirstCoordinate + distance, SecondCoordinate + distance);
                case Geometry.Direction.LeftDown:
                    return new Square(FirstCoordinate - distance, SecondCoordinate - distance);
                case Geometry.Direction.RightDown:
                    return new Square(FirstCoordinate + distance, SecondCoordinate - distance);
            }
            return new Square();
        }

        public Draught CreateDraught(Geometry.Direction direction, int distance,
            Peculiarity.Colours colour)
        {
            return new Draught(CreateSquare(direction, distance), colour);
        }

        public StringBuilder CoordinatesToUser()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Convert.ToChar(FirstCoordinate + Constants.CODE_OF_a - 1));
            str.Append(SecondCoordinate);
            return str;
        }

        private bool InLimit(int coordinate)
        {
            return (LowLimit <= coordinate && coordinate <= UpperLimit);
        }

        private bool OnRightSquares()
        {
            return ((FirstCoordinate + SecondCoordinate) % 2 == 0);
        }
        
    }
}
