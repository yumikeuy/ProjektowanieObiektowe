using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities
{
    public class Hand : ITextConvertible, IHand
    {
        private IItem? _item;
        public Point PrintAt { get; set; } = new(0, 0);
        private Hands leftOrRight;

        public Hand(Point printAt)
        {
            PrintAt = printAt;
        }
        public Hand(Hands leftOrRight)
        {
            this.leftOrRight = leftOrRight;
        }
        public Hand() { }

        public bool TryAdd(IItem item)
        {
            if(_item != null) return false;
            _item = item;
            return true;
        }

        public IItem? Remove()
        {
            var tmp = _item;
            _item = null;
            return tmp;
        }

        public Printable Text()
        {
            var clear = "                                     ";
            Printable p = new();
            var itemText = _item == null ? clear : _item.Description;
            p.AddText(new($"{leftOrRight} Hand: " + itemText, PrintAt));
            return p;
        }
    }
}
