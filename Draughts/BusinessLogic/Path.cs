using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Path : IToUser
    {
        private List<Square> points = new List<Square>();

        public List<Square> Points { get { return points; } }

        public Path(Square square)
        {
            Points.Add(square);
        }

        public void Add(Square square)
        {
            Points.Add(square);
        }
        
        public StringBuilder CoordinatesToUser()
        {
            StringBuilder str = new StringBuilder();
            foreach (var square in Points)
            {
                str.Append(square.CoordinatesToUser());
                str.Append("-");
            }
            str.Remove(str.Length - 1, 1);
            str.Append(";");
            return str;
        }
    }
}
