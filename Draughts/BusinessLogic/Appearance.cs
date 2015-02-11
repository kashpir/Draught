using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{

    public enum ColourNames { White, Black };
    public enum ItemStatus { Man, King };

    public class Appearance
    {
        public ColourNames Colour { get; private set; }
        public ItemStatus Status { get; private set; }
        public bool GetDirectionsForTaking { get; set; }

        public Appearance(char ch)
        {
            Colour = (ch == Constants.WHITE) ? ColourNames.White : ColourNames.Black;
            Status = ItemStatus.Man;
        }

        public Appearance(ColourNames colour)
        {
            Colour = colour;
            Status = ItemStatus.Man;
        }

        public Appearance InverseColour()
        {
            var colour = (Colour == ColourNames.White) ? ColourNames.Black : ColourNames.White;
            return new Appearance(colour);
        }

        public bool AreEqual(Appearance clothes)
        {
            return (clothes.Colour == Colour && clothes.Status == Status);
        }
    }
}
