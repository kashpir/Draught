using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public static class Geometry
    {
        public enum Direction { RightUp, LeftUp, RightDown, LeftDown }

        public static Direction Inverse(Direction direction)
        {
            switch (direction)
            {
                case Direction.LeftUp: return Direction.RightDown;
                case Direction.RightUp: return Direction.LeftDown;
                case Direction.LeftDown: return Direction.RightUp;
                case Direction.RightDown: return Direction.LeftUp;
            }
            return direction;
        }
    }
}
