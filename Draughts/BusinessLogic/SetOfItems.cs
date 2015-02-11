using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class SetOfItems
    {
        private List<Item> arrangement = new List<Item>();

        public List<Item> Arrangement
        {
            get { return arrangement; }
        }

        public SetOfItems() { }

        public SetOfItems(List<Item> arrangement) { this.arrangement = arrangement; }

        public SetOfItems(string line)
        {
            for (var i = 0; i < line.Length;
                i += (Constants.CHARS_CODE_DRAUGHT + Constants.CHARS_SEPARATE_DRAUGHTS))
                AddItem(new Item(line.Substring(i, Constants.CHARS_CODE_DRAUGHT)));
        }

        public int IndexOf(Item item)
        {
            for (int i = 0; i < Arrangement.Count; i++)
                if (Arrangement[i].AreEqual(item)) return i;
            return -1;
        }

        public int IndexOf(IVector square)
        {
            for (int i = 0; i < Arrangement.Count; i++)
                if (Arrangement[i].Coordinates.AreEqual(square)) return i;
            return -1;
        }

        public bool Contain(Square square)
        {
            return (IndexOf(square) >= 0);
        }

        public bool Contain(Item item)
        {
            return (IndexOf(item) >= 0);
        }

        public void AddItem(Item item)
        {
            Arrangement.Add(item);
        }

        public void DeleteItem(Item item)
        {
            if (Contain(item)) arrangement.RemoveAt(IndexOf(item));
        }

        public SetOfItems Clone()
        {
            var list = new List<Item>();
            foreach (var item in Arrangement)
                list.Add(item);
            return new SetOfItems(list);
        }

    }
}
