using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;

namespace Lab1.Library.Interfaces
{
    public interface IHandInventoryTransfer
    {
        public bool TransferFromInventoryToHands(int itemIndex);
        public bool TransferFromHandsToInventory();
    }
}
