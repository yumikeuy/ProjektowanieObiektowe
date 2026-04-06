using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Entities.Inventory
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
            if (_item != null) return false;
            _item = item;
            return true;
        }

        public IItem? Remove()
        {
            var tmp = _item;
            _item = null;
            return tmp;
        }

        public IPrintable Text()
        {
            Printable p = new();
            var itemText = _item == null ? "" : _item.Description;
            p.AddText(new TextPos($"{leftOrRight} Hand: " + itemText, PrintAt));
            return p;
        }

        public void ActivateItem(IPlayerState playerState)
        {
            _item?.Activate(playerState);
        }
        public void DeactivateItem(IPlayerState playerState)
        {
            _item?.Deactivate(playerState);
        }
    }
}
