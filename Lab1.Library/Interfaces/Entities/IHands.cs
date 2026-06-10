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
        void SelectHand(Hands hand);
        bool TryAdd(IItem item);
        bool TryAdd(ICollection<IItem> items);
        ICollection<IItem> AddOrSwap(IItem item);
        ICollection<IItem>? AddOrSwap(ICollection<IItem> items);
        (IItem? left, IItem? right) GetItemsFromHands();
        bool TryAddToLeft(IItem item);
        bool TryAddToRight(IItem item);
        IItem? TryRemoveLeft();
        IItem? TryRemoveRight();
        IItem? Remove();
        IItem? GetCurrentItem();
    }
}
