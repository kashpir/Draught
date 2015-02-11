using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Position
    {
        private SetOfItems state;
        private readonly Appearance whoseMove;

        public SetOfItems State { get { return state; } }
        public ColourNames WhoseMove { get { return whoseMove.Colour; } }

        public Position(SetOfItems state, ColourNames whoseMove)
        {
            this.state = state;
            this.whoseMove = new Appearance(whoseMove);
        }

        public bool TakingExists()
        {
            foreach (var draught in State.Arrangement)
            {
                var draughtInPlay = new ItemInPlay(draught, State);
                if (WhoseMove == draught.Colour() && draughtInPlay.TakingExists()) return true;
            }
            return false;
        }


        public Paths Takings()
        {
            var moves = new Paths();
            foreach (var draught in State.Arrangement)
            {
                var draughtInPlay = new ItemInPlay(draught, State.Clone());
                if (WhoseMove == draught.Colour() && draughtInPlay.TakingExists())
                    moves.AddMoves(draughtInPlay.Moves());
            }
            return moves;
        }

        public Paths SimpleMoves()
        {
            var moves = new Paths();
            foreach (var draught in State.Arrangement)
            {
                var draughtInPlay = new ItemInPlay(draught, State);
                if (WhoseMove == draught.Colour())
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
