using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public enum Towards { RightUp, LeftUp, RightDown, LeftDown }

    public class Direction : IVector
    {
        public Towards Course { get; private set; }

        public Direction(Towards course)
        {
            Course = course;
        }

        public int FirstNumber
        {
            get
            {
                if (Course == Towards.LeftUp || Course == Towards.LeftDown) return -1;
                return 1;
            }
        }

        public int SecondNumber
        {
            get
            {
                if (Course == Towards.LeftDown || Course == Towards.RightDown) return -1;
                return 1;
            }
        }
        
    }
}
