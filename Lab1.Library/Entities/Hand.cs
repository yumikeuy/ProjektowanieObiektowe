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
    public class Hand : IPrintable
    {
        private Item? _item;
        public Point PrintAt { get; set; } = new(0, 0);
        public Hands LeftOrRight { get; set; }

        public Hand(Point printAt)
        {
            PrintAt = printAt;
        }
        public Hand(Hands leftOrRight)
        {
            LeftOrRight = leftOrRight;
        }
        public Hand() { }

        public bool TryAdd(Item item)
        {
            if(_item != null) return false;
            _item = item;
            return true;
        }

        public Item? Remove()
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
            p.AddText(new($"{LeftOrRight} Hand: " + itemText, PrintAt));
            return p;
        }
    }
}
