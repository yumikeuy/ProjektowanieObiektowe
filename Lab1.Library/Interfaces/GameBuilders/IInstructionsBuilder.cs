using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.GameBuilders
{
    public interface IInstructionsBuilder
    {
        public IInstructionsBuilder Initialize(Point printAt);
        public IInstructionsBuilder AddItems();
        public IInstructionsBuilder AddEnemies();
        public IInstructions GetResult();
    }
}
