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
            _instructions.AddHandler(new MovementHandler());
            return this;
        }
        public IInstructionsBuilder AddItems()
        {
            _instructions.AddHandler(new ItemsInputHandler());
            return this;
        }
        public IInstructions GetResult()
        {
            return _instructions;
        }
    }
}
