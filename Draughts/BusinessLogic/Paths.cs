using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Paths
    {
        private List<Path> moves = new List<Path>();

        public List<Path> Moves { get { return moves; } }

        public void AddMoves(Paths moves)
        {
            foreach (var move in moves.Moves)
                Moves.Add(move);
        }

        public void AddPath(Path path)
        {
            Moves.Add(path);
        }

        public void InsertAtBeginning(Square square)
        {
            foreach (var element in Moves)
                element.Points.Insert(0, square);
        }

        public void Show()
        {
            foreach (var path in Moves)
                Console.WriteLine(path.CoordinatesToUser().ToString());
        }

        public int Count()
        {
            return Moves.Count();
        }

    }
}
