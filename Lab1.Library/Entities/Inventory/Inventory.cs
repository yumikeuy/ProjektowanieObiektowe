using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Entities.Inventory
{
    public class Inventory : IInventory
    {
        private ICollection<Item> _items = [];
        private int _inventorySize = 5;
        public Point PrintAt { get; set; } = new(0, 0);

        private bool IsInventoryFull() => IsInventoryFull(1);
        private bool IsInventoryFull(int newItems) => _items.Count + newItems > _inventorySize;

        public bool TryAdd(Item item)
        {
            if (!IsInventoryFull())
            {
                _items.Add(item);
                return true;
            }

            return false;
        }
        public bool TryAdd(ICollection<Item> items)
        {
            if (!IsInventoryFull(items.Count))
            {
                foreach (var item in items)
                    _items.Add(item);

                return true;
            }

            return false;
        }
        public Item? TryRemove(int itemIndex)
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
            int i = 0;
            foreach (var item in _items)
                p.AddText(new TextPos($"{++i}. " + item.Description, new(PrintAt.X, PrintAt.Y + i)));

            return p;
        }
    }
}
