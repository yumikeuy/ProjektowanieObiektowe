using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class HandInventoryTransfer
    {
        private Inventory _inventory;
        private TwoHands _hands;

        public HandInventoryTransfer(TwoHands hands, Inventory inventory)
        {
            _hands = hands;
            _inventory = inventory;
        }

        public bool TransferFromInventoryToHands(int itemIndex)
        {
            var item = _inventory.TryRemove(itemIndex);
            if (item == null) return false;

            var itemsFromHands = _hands.AddOrSwap(item);
            if (itemsFromHands.Count == 0) return true;
            
            if(_inventory.TryAdd(itemsFromHands)) return true;

            var items = _hands.AddOrSwap(itemsFromHands) 
                ?? throw new Exception("Poorly managed Hands-Inventory Transfer.");
            if(!_inventory.TryAdd(items))
                throw new Exception("Poorly managed Hands-Inventory Transfer.");

            return false;
        }

        public bool TransferFromHandsToInventory()
        {
            var item = _hands.Remove();
            if (item == null) return false;

            if (_inventory.TryAdd(item)) return true;

            if (!_hands.TryAdd(item))
                throw new Exception("Poorly managed Hands-Inventory Transfer.");

            return false;
        }
    }
}
//TODO
// Interfaces
// Printing
// Program.cs
// Zad 2
// other TODOs