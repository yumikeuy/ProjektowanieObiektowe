using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities
{
    public class Inventory : IPrintable
    {

        public List<Item> Items { get; set; } = [];
        public Point PrintAt { get; set; } = new(0, 0);

        public bool HasChanged { get; set; } = false;

        private int _inventorySize = 5;
        private int _count => Items.Count;
        private bool IsInventoryFull() => IsInventoryFull(1);
        private bool IsInventoryFull(int newItems) => _count + newItems > _inventorySize;


        public bool TryAdd(Item item)
        {
            if (!IsInventoryFull())
            {
                Items.Add(item);
                HasChanged = true;
                return true;
            }

            return false;
        }
        public bool TryAdd(List<Item> items)
        {
            if (!IsInventoryFull(items.Count))
            {
                Items.AddRange(items);
                HasChanged = true;
                return true;
            }

            return false;
        }
        public Item? TryRemove(int itemIndex)
        {
            if (Items.Count <= itemIndex) return null;
            var item = Items[itemIndex];
            Items.RemoveAt(itemIndex);
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

        public void Print()
        {
            //TODO
        }
    }
}
