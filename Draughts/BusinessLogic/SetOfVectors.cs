using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class SetOfVectors
    {
        private List<IVector> vectors = new List<IVector>();

        public List<IVector> Points { get { return vectors; } }

        public SetOfVectors() { }

        public SetOfVectors(IVector vector)
        {
            Points.Add(vector);
        }

        public void Add(IVector vector)
        {
            Points.Add(vector);
        }

        public bool AreEqual(int i, IVector vector)
        {
            if (i >= vectors.Count) return false;
            return ((vectors[i].FirstNumber == vector.FirstNumber) &&
                    (vectors[i].SecondNumber == vector.SecondNumber));
        }
    }
}
