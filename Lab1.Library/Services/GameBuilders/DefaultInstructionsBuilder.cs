using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.GameBuilders;
using Lab1.Library.Services.GameInstructions;
using Lab1.Library.Services.InputHandlers;

namespace Lab1.Library.Services.GameBuilders
{
    public class DefaultInstructionsBuilder : IInstructionsBuilder
    {
        private IInstructions _instructions = null!;
        private bool isInitialized = false;
        private bool addedItems = false;

        public IInstructionsBuilder Initialize(Point printAt)
        {
            if (isInitialized) return this;

            _instructions = new Instructions(printAt);
            _instructions.AddHandler(new MovementHandler());

            isInitialized = true;
            return this;
        }
        public IInstructionsBuilder AddItems()
        {
            if (!isInitialized) throw new InvalidOperationException("Instructions are not initialized");
            if (addedItems) return this;
            _instructions.AddHandler(new ItemsInputHandler());
            addedItems = true;
            return this;
        }
        public IInstructionsBuilder AddEnemies()
        {
            if (!isInitialized) throw new InvalidOperationException("Instructions are not initialized");
            _instructions.AddHandler(new EnemiesHandler());
            return this;
        }
        public IInstructions GetResult()
        {
            return _instructions;
        }
    }
}
