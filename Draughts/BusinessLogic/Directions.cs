using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Directions
    {
        public List<IVector> DirectionsRequired { get; set; }

        public Directions(Appearance clothes)
        {
            DirectionsRequired = new List<IVector>();
            if (clothes.GetDirectionsForTaking) DirectionsForTaking();
            else if (clothes.Status == ItemStatus.King) DirectionsForKing();
            else if (clothes.Colour == ColourNames.White) DirectionsForWhite();
            else DirectionsForBlack();
        }

        private void DirectionsForTaking()
        {
            foreach (Towards towards in Enum.GetValues(typeof(Towards)))
                Merge(DirectionAlong(towards, Constants.DISTANCE_FOR_SIMPLE_TAKING));
        }

        private void DirectionsForKing()
        {
            foreach (Towards towards in Enum.GetValues(typeof(Towards)))
                Merge(DirectionsAlong(towards));
        }

        private void DirectionsForWhite()
        {
            Merge(DirectionAlong(Towards.RightUp, Constants.DISTANCE_FOR_SIMPLE_MOVE));
            Merge(DirectionAlong(Towards.LeftUp, Constants.DISTANCE_FOR_SIMPLE_MOVE));
        }

        private void DirectionsForBlack()
        {
            Merge(DirectionAlong(Towards.RightDown, Constants.DISTANCE_FOR_SIMPLE_MOVE));
            Merge(DirectionAlong(Towards.LeftDown, Constants.DISTANCE_FOR_SIMPLE_MOVE));
        }

        private List<IVector> DirectionsAlong(Towards towards)
        {
            var list = new List<IVector>();
            var vector = CreateVector(towards);
            for (int i = 1; i < BoardGeometry.DRAUGHT_BOARD_WIDTH; i++)
                list.Add(vector.Multiple(i));
            return list;
        }

        private List<IVector> DirectionAlong(Towards towards, int distanse)
        {
            var list = new List<IVector>();
            var vector = CreateVector(towards).Multiple(distanse);
            list.Add(vector);
            return list;
        }

        private void Merge(List<IVector> vectors)
        {
            foreach (var element in vectors)
                DirectionsRequired.Add(element);
        }
        
        private static Vector CreateVector(Towards towards)
        {
            var direction = new Direction(towards);
            return new Vector(direction);
        }
    }
}
