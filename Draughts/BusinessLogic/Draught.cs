using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BusinessLogic
{
    public class Draught : ICreate
    {
        public Square Coordinates { get; private set; }
        public Peculiarity.Colours Colour { get; private set; }

        public Draught(int first, int second, Peculiarity.Colours colour)
        {
            Coordinates = new Square(first, second);
            Colour = colour;
        }

        public Draught(string line)
        {
            Colour = Peculiarity.GetColour(line[0]);
            Coordinates = new Square(line.Substring(1, Constants.CHARS_CODE_SQUARE));
        }

        public Draught(Square square, Peculiarity.Colours colour)
        {
            Coordinates = square;
            Colour = colour;
        }

        public bool AreEqual(Draught draught)
        {
            return ((draught.Colour == Colour) &&
                ((draught.Coordinates.AreEqual(Coordinates))));
        }

        public Square CreateSquare(Geometry.Direction direction, int distance)
        {
            return Coordinates.CreateSquare(direction, distance);
        }

        public Draught CreateDraught(Geometry.Direction direction, int distance,
            Peculiarity.Colours colour)
        {
            return new Draught(Coordinates.CreateSquare(direction, distance), colour);
        }

        public Draught Clone()
        {
            return new Draught(Coordinates.FirstCoordinate, Coordinates.SecondCoordinate,
                Colour);
        }
    }
}
