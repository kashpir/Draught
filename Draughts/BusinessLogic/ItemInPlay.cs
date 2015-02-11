using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace BusinessLogic
{
    public class ItemInPlay
    {
        private Item mainItem;
        private readonly SetOfItems state;
        private SetOfItems captured = new SetOfItems();
        private BoardGeometry geometry = new BoardGeometry();


        public Item MainItem
        {
            get { return mainItem; }
            private set { mainItem = value; }
        }
        public SetOfItems State { get { return state; } }
        private SetOfItems Captured { get { return captured; } }
        private BoardGeometry Geometry { get { return geometry; } }

        public ItemInPlay(Item item, SetOfItems position)
        {
            if (MainItemInPosition(item, position))
            {
                mainItem = item;
                state = position;
            }
        }

        public Paths Moves()
        {
            if (TakingExists()) return Takings();
            if (MainItem.Colour() == ColourNames.White) return SimpleMovesForWhite();
            return SimpleMovesForBlack();
        }

        public Paths SimpleMovesForWhite()
        {
            var moves = new Paths();
            if (SimpleMoveExists(Towards.LeftUp))
                moves.AddPath(SimpleMove(Towards.LeftUp));
            if (SimpleMoveExists(Towards.RightUp))
                moves.AddPath(SimpleMove(Towards.RightUp));
            return moves;
        }

        public Paths SimpleMovesForBlack()
        {
            var moves = new Paths();
            if (SimpleMoveExists(Towards.LeftDown))
                moves.AddPath(SimpleMove(Towards.LeftDown));
            if (SimpleMoveExists(Towards.RightDown))
                moves.AddPath(SimpleMove(Towards.RightDown));
            return moves;
        }

        public Paths Takings()
        {
            var moves = new Paths();
            foreach (Towards direction in Enum.GetValues(typeof(Towards)))
            {
                if (TakingExists(direction))
                    moves.AddMoves(Takings(direction));
            }
            return moves;
        }

        public bool TakingExists()
        {
            foreach (Towards towards in Enum.GetValues(typeof(Towards)))
                if (TakingExists(towards)) return true;
            return false;
        }

        private bool MainItemInPosition(Item MainItem, SetOfItems position)
        {
            foreach (var item in position.Arrangement)
                if (item.AreEqual(MainItem)) return true;
            return false;
        }

        private Path SimpleMove(Towards towards)
        {
            var list = new Path(MainItem.Coordinates);
            var direction = new Direction(towards);
            var square = Geometry.ShiftSquare(MainItem.Coordinates, direction);
            list.Add(square);
            return list;
        }

        private Paths Takings(Towards towards)
        {
            var moves = new Paths();
            var direction = new Direction(towards);
            var vector = new Vector(direction);
            var nextCapturedItem = CreateDraught(vector, MainItem.Clothes.InverseColour());
            MoveMainItem(vector.Multiple(Constants.DISTANCE_FOR_SIMPLE_TAKING));
            Captured.AddItem(nextCapturedItem);
            if (TakingExists()) moves.AddMoves(Takings());
            else moves.AddPath(new Path(MainItem.Coordinates));
            MoveMainItem(vector.Multiple(-1 * Constants.DISTANCE_FOR_SIMPLE_TAKING));
            Captured.DeleteItem(nextCapturedItem);
            moves.InsertAtBeginning(MainItem.Coordinates);
            return moves;
        }

        private bool SimpleMoveExists(Towards towards)
        {
            var direction = new Direction(towards);
            var square = Geometry.ShiftSquare(MainItem.Coordinates, direction);
            return (Geometry.ValidSquare(square) && !State.Contain(square));
        }

        private bool TakingExists(Towards towards)
        {
            var direction = new Direction(towards);
            var vector = new Vector(direction);
            var draught = CreateDraught(vector, MainItem.Clothes.InverseColour());
            var square = Geometry.ShiftSquare(MainItem.Coordinates,
                vector.Multiple(Constants.DISTANCE_FOR_SIMPLE_TAKING));
            return (State.Contain(draught) && !Captured.Contain(draught) &&
                Geometry.ValidSquare(square) && !State.Contain(square));
        }

        private Item CreateDraught(IVector vector, Appearance clothes)
        {
            var square = geometry.ShiftSquare(MainItem.Coordinates, vector);
            return new Item(square, clothes);
        }

        private void MoveMainItem(IVector vector)
        {
            var item = CreateDraught(vector, MainItem.Clothes);
            State.AddItem(item);
            State.DeleteItem(MainItem);
            MainItem = item;
        }
    }
}

