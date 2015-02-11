using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BusinessLogic
{
    public class Item : IVector
    {
        private readonly Square coordinates;
        private readonly Appearance clothes;

        public Square Coordinates { get { return coordinates; } }
        public Appearance Clothes { get { return clothes; } }

        public Item(int first, int second, ColourNames colour)
        {
            coordinates = new Square(first, second);
            clothes = new Appearance(colour);
        }

        public Item(string line)
        {
            clothes = new Appearance(line[0]);
            coordinates = new Square(line.Substring(1, Constants.CHARS_CODE_SQUARE));
        }

        public Item(Square square, Appearance clothes)
        {
            coordinates = square;
            this.clothes = clothes;
        }

        public bool AreEqual(Item item)
        {
            return ((item.Clothes.AreEqual(Clothes)) &&
                ((item.Coordinates.AreEqual(Coordinates))));
        }

        public ColourNames Colour()
        {
            return Clothes.Colour;
        }

        public int FirstNumber
        {
            get { return Coordinates.FirstCoordinate; }
        }

        public int SecondNumber
        {
            get { return Coordinates.SecondCoordinate; }
        }
    }
}
