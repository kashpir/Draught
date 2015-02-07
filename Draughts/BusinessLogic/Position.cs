using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Position
    {
        private SetOfDraughts state;
        private readonly Peculiarity.Colours whoseMove;

        public SetOfDraughts State { get { return state; } }
        public Peculiarity.Colours WhoseMove { get { return whoseMove; } }

        public Position(SetOfDraughts state, Peculiarity.Colours whoseMove)
        {
            this.state = state;
            this.whoseMove = whoseMove;
        }

        public bool TakingExists()
        {
            foreach (var draught in State.Arrangement)
            {
                var draughtInPlay = new DraughtInPlay(draught, State);
                if (WhoseMove == draught.Colour && draughtInPlay.TakingExists()) return true;
            }
            return false;
        }


        public Paths Takings()
        {
            var moves = new Paths();
            foreach (var draught in State.Arrangement)
            {
                var draughtInPlay = new DraughtInPlay(draught, State.Clone());
                if (WhoseMove == draught.Colour && draughtInPlay.TakingExists())
                    moves.AddMoves(draughtInPlay.Moves());
            }
            return moves;
        }

        public Paths SimpleMoves()
        {
            var moves = new Paths();
            foreach (var draught in State.Arrangement)
            {
                var draughtInPlay = new DraughtInPlay(draught, State);
                if (WhoseMove == draught.Colour)
                    moves.AddMoves(draughtInPlay.Moves());
            }
            return moves;
        }

        public Paths Moves()
        {
            return TakingExists() ? Takings() : SimpleMoves();
        }
    }
}
