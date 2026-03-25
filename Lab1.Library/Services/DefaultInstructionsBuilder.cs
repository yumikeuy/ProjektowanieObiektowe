using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameInstructions;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public class DefaultInstructionsBuilder : IInstructionsBuilder
    {
        private IInstructions _instructions = null!;
        public IInstructionsBuilder Initialize(Point printAt)
        {
            _instructions = new Instructions(printAt);
            _instructions.Add(new MovementInstruction());
            return this;
        }
        public IInstructionsBuilder AddItems()
        {
            //_instructions.Add(new PickUpInstruction());
            _instructions.Add(new HideItemToInventory());
            _instructions.Add(new DropItemInstruction());
            _instructions.Add(new SelectHandInstruction());
            _instructions.Add(new TakeFromInventoryInstruction());

            return this;
        }
        public IInstructions GetResult()
        {
            return _instructions;
        }
    }
}
