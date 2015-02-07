using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class SetOfDraughts
    {
        private List<Draught> arrangement = new List<Draught>();

        public List<Draught> Arrangement
        {
            get { return arrangement; }
        }

        public SetOfDraughts() { }

        public SetOfDraughts(List<Draught> arrangement) { this.arrangement = arrangement; }

        public SetOfDraughts(string line)
        {
            for (var i = 0; i < line.Length;
                i += (Constants.CHARS_CODE_DRAUGHT + Constants.CHARS_SEPARATE_DRAUGHTS))
                AddDraught(new Draught(line.Substring(i, Constants.CHARS_CODE_DRAUGHT)));
        }

        public int IndexOf(Draught draught)
        {
            for (int i = 0; i < Arrangement.Count; i++)
                if (Arrangement[i].AreEqual(draught)) return i;
            return -1;
        }

        public bool Contain(Square place)
        {
            var draughtWhite = new Draught(place, Peculiarity.Colours.White);
            var draughtBlack = new Draught(place, Peculiarity.Colours.Black);
            return (Contain(draughtWhite) || Contain(draughtBlack));
        }

        public bool Contain(Draught draught)
        {
            return (IndexOf(draught) >= 0);
        }
        
        public void AddDraught(Draught draught)
        {
            Arrangement.Add(draught);
        }

        public void DeleteDraught(Draught draught)
        {
            if (Contain(draught)) arrangement.RemoveAt(IndexOf(draught));
        }

        public SetOfDraughts Clone()
        {
            var list = new List<Draught>();
            foreach (var draught in Arrangement)
            {
                var newdraught = draught.Clone();
                list.Add(newdraught);
            }
            return new SetOfDraughts(list);
        }

    }
}
