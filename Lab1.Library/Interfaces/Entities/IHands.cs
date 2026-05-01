using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Entities.Inventory;
using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IHands : ITextConvertible
    {
        public void SelectHand(Hands hand);
        public bool TryAdd(IItem item);
        public bool TryAdd(ICollection<IItem> items);
        public ICollection<IItem> AddOrSwap(IItem item);
        public ICollection<IItem>? AddOrSwap(ICollection<IItem> items);
        public IItem? Remove();
        public IItem? GetCurrentItem();
    }
}
