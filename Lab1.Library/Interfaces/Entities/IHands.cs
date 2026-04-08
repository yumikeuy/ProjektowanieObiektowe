using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Entities.Inventory;
using Lab1.Library.Entities.GameObjects.Items;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IHands : ITextConvertible
    {
        public void SelectHand(Hands hand);
        public bool TryAdd(Item item);
        public bool TryAdd(ICollection<Item> items);
        public ICollection<Item> AddOrSwap(Item item);
        public ICollection<Item>? AddOrSwap(ICollection<Item> items);
        public Item? Remove();
        public Item? GetCurrentItem();
    }
}
