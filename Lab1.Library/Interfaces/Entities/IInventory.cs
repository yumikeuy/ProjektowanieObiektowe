using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IInventory : ITextConvertible
    {
        public bool TryAdd(Item item);
        public bool TryAdd(ICollection<Item> items);
        public Item? TryRemove(int itemIndex);
    }
}
