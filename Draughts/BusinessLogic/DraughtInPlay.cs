using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace BusinessLogic
{
    public class DraughtInPlay
    {

        private Draught mainDraught;
        private readonly SetOfDraughts state;
        private SetOfDraughts captured = new SetOfDraughts();

        public Draught MainDraught
        {
            get { return mainDraught; }
            private set { mainDraught = value; }
        }
        public SetOfDraughts State { get { return state; } }
        private SetOfDraughts Captured { get { return captured; } }

        public DraughtInPlay(Draught draught, SetOfDraughts position)
        {
            if (MainDraughtInPosition(draught, position))
            {
                mainDraught = draught;
                state = position;
            }
        }

        public Paths Moves()
        {
            if (TakingExists()) return Takings();
            if (MainDraught.Colour == Peculiarity.Colours.White) return SimpleMovesForWhite();
            return SimpleMovesForBlack();
        }

        public Paths SimpleMovesForWhite()
        {
            var moves = new Paths();
            if (SimpleMoveExists(Geometry.Direction.LeftUp))
                moves.AddPath(SimpleMove(Geometry.Direction.LeftUp));
            if (SimpleMoveExists(Geometry.Direction.RightUp))
                moves.AddPath(SimpleMove(Geometry.Direction.RightUp));
            return moves;
        }

        public Paths SimpleMovesForBlack()
        {
            var moves = new Paths();
            if (SimpleMoveExists(Geometry.Direction.LeftDown))
                moves.AddPath(SimpleMove(Geometry.Direction.LeftDown));
            if (SimpleMoveExists(Geometry.Direction.RightDown))
                moves.AddPath(SimpleMove(Geometry.Direction.RightDown));
            return moves;
        }

        public Paths Takings()
        {
            var moves = new Paths();
            foreach (Geometry.Direction direction in Enum.GetValues(typeof(Geometry.Direction)))
            {
                if (TakingExists(direction))
                    moves.AddMoves(Takings(direction));
            }
            return moves;
        }

        public bool TakingExists()
        {
            foreach (Geometry.Direction direction in Enum.GetValues(typeof(Geometry.Direction)))
                if (TakingExists(direction)) return true;
            return false;
        }

        private bool MainDraughtInPosition(Draught MainDraught, SetOfDraughts position)
        {
            foreach (var draught in position.Arrangement)
                if (draught.AreEqual(MainDraught)) return true;
            return false;
        }

        private Path SimpleMove(Geometry.Direction direction)
        {
            var list = new Path(MainDraught.Coordinates);
            var square = MainDraught.CreateSquare(direction, Constants.DISTANCE_FOR_SIMPLE_MOVE);
            list.Add(square);
            return list;
        }

        private Paths Takings(Geometry.Direction direction)
        {
            var moves = new Paths();
            var nextCapturedDraught = MainDraught.CreateDraught(direction,
                Constants.DISTANCE_FOR_SIMPLE_MOVE, Peculiarity.Inverse(MainDraught.Colour));
            MoveMainDraught(direction, Constants.DISTANCE_FOR_SIMPLE_TAKING);
            Captured.AddDraught(nextCapturedDraught);
            if (TakingExists()) moves.AddMoves(Takings());
            else moves.AddPath(new Path(MainDraught.Coordinates));
            MoveMainDraught(Geometry.Inverse(direction), Constants.DISTANCE_FOR_SIMPLE_TAKING);
            Captured.DeleteDraught(nextCapturedDraught);
            moves.InsertAtBeginning(MainDraught.Coordinates);
            return moves;
        }

        private bool SimpleMoveExists(Geometry.Direction direction)
        {
            var square = MainDraught.CreateSquare(direction, Constants.DISTANCE_FOR_SIMPLE_MOVE);
            return (square.OnBoard() && !State.Contain(square));
        }
        
        private bool TakingExists(Geometry.Direction direction)
        {
            var draught = MainDraught.CreateDraught(direction, Constants.DISTANCE_FOR_SIMPLE_MOVE,
                Peculiarity.Inverse(MainDraught.Colour));
            var square = MainDraught.CreateSquare(direction, Constants.DISTANCE_FOR_SIMPLE_TAKING);
            return (State.Contain(draught) && !Captured.Contain(draught) &&
                square.OnBoard() && !State.Contain(square));
        }

        private void MoveMainDraught(Geometry.Direction direction, int distance)
        {
            var draught = MainDraught.CreateDraught(direction, distance, MainDraught.Colour);
            State.AddDraught(draught);
            State.DeleteDraught(MainDraught);
            MainDraught = draught;
        }
    }
}

