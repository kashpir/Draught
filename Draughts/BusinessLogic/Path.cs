using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Path : SetOfVectors
    {
        public Path(IVector vector)
            : base(vector)
        { }

        public StringBuilder CoordinatesToUser()
        {
            StringBuilder str = new StringBuilder();
            foreach (var vector in Points)
            {
                var square = new Square(vector.FirstNumber, vector.SecondNumber);
                str.Append(square.CoordinatesToUser());
                str.Append("-");
            }
            str.Remove(str.Length - 1, 1);
            str.Append(";");
            return str;
        }
    }
}
