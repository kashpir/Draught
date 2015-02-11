using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;

namespace Draughts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var arrangement = new SetOfItems("wa1; bb2; bb4; bb6;");
            var position = new Position(arrangement, ColourNames.White);
            position.Moves().Show();
            Console.ReadLine();
        }
    }
}
