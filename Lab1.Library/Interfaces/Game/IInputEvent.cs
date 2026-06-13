using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.Game
{
    public interface IInputEvent
    {
        public ConsoleKey Key { get; set; }
        public IPlayer Player { get; set; }
        public bool IsHandled { get; set; }
        public IGame Game { get; set; }
    }
}
