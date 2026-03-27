using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameInstructions;

namespace Lab1.Library.Services
{
    public class ItemsInputHandler : InputHandler
    {
        public ItemsInputHandler()
        {
            _instructions.Add(new TakeFromInventoryInstruction());
            _instructions.Add(new SelectHandInstruction());
            _instructions.Add(new HideItemToInventory());
            _instructions.Add(new DropItemInstruction());
            //_instructions.Add(new PickUpInstruction());
        }
    }
}
