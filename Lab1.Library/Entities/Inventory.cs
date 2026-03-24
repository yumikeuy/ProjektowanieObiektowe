using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;

namespace Lab1.Library.Entities
{
    public class Inventory : IInventory
    {
        private ICollection<IItem> _items = [];
        private int _inventorySize = 5;
        public Point PrintAt { get; set; } = new(0, 0);

        private bool IsInventoryFull() => IsInventoryFull(1);
        private bool IsInventoryFull(int newItems) => _items.Count + newItems > _inventorySize;

        public bool TryAdd(IItem item)
        {
            if (!IsInventoryFull())
            {
                _items.Add(item);
                return true;
            }

            return false;
        }
        public bool TryAdd(ICollection<IItem> items)
        {
            if (!IsInventoryFull(items.Count))
            {
                foreach(var item in items) 
                    _items.Add(item);

                return true;
            }

            return false;
        }
        public IItem? TryRemove(int itemIndex)
        {
            if (_items.Count <= itemIndex) return null;
            var item = _items.ToList()[itemIndex];
            var itemList = _items.ToList();
            itemList.RemoveAt(itemIndex);
            _items = itemList;
            return item;
        }

        public Inventory(Point printAt, int invSize = 5)
        {
            PrintAt = printAt;
            _inventorySize = invSize;
        }
        public Inventory(int invSize = 5)
        {
            _inventorySize = invSize;
        }

        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos("Inventory : ", PrintAt));
            var clear = "                         ";
            int i = 0;
            foreach (var item in _items)
                p.AddText(new TextPos($"{++i}. " + item.Description + clear, new(PrintAt.X, PrintAt.Y + i)));

            for (int j = i + 1; j <= _inventorySize + i; j++)
                p.AddText(new TextPos(clear, new(PrintAt.X, PrintAt.Y + j)));

            return p;
        }
    }
}
