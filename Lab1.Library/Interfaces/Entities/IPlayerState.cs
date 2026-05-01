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
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Luck { get; set; }
        public int Agility { get; set; }
        public int Agressiveness { get; set; }
        public int Iq { get; set; }
        public int Coins { get; set; }
        public int Gold { get; set; }
        public int Armor { get; set; }

        public char Orientation { get; set; }

        public bool TryAdd(IItem item);
        public IItem? Drop();
        public void SelectHand(Hands hand);
        public IHandInventoryTransfer GetInventoryTransfer();
        public IItem? GetCurrentItem();
    }
}
