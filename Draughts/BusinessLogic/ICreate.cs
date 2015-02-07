using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    interface ICreate
    {
        Square CreateSquare(Geometry.Direction direction, int distance);
        Draught CreateDraught(Geometry.Direction direction, int distance, Peculiarity.Colours colour);
        
    }
}
