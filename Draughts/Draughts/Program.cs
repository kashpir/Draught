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
            var arrangement = new SetOfDraughts("wa1; wc1; bb2; bb4; bb6;");
            var colour = Peculiarity.Colours.Black;
            var position = new Position(arrangement, colour);
            position.Moves().Show();
            Console.ReadLine();
        }
    }
}
