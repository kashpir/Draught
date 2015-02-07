using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public static class Peculiarity
    {
        public enum Colours { White, Black };

        public static Colours Inverse(Colours initial)
        {
            switch (initial)
            {
                case Colours.White:
                    return Colours.Black;
                case Colours.Black:
                    return Colours.White;
            }
            return Colours.White;
        }

        public static Colours GetColour(char ch)
        {
            return ch == Constants.BLACK ? Colours.Black : Colours.White;
        }
    }
}
