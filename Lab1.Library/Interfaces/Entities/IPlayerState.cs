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
    public interface IPlayerState : ITextConvertible
    {
        int Damage { get; set; }
        int Health { get; set; }
        int Luck { get; set; }
        int Agility { get; set; }
        int Agressiveness { get; set; }
        int Iq { get; set; }
        int Coins { get; set; }
        int Gold { get; set; }
        int Armor { get; set; }
        bool HasChanged { get; set; }

        char Orientation { get; set; }

        bool TryAdd(IItem item);
        IItem? Drop();
        void SelectHand(Hands hand);
        IHandInventoryTransfer GetInventoryTransfer();
        (IItem? left, IItem? right) GetItemsFromHands();
        bool TryAddToLeft(IItem item);
        bool TryAddToRight(IItem item);
        IItem? TryRemoveLeft();
        IItem? TryRemoveRight();
        IItem? GetCurrentItem();
        IInventory GetInventory();
    }
}
