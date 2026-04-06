using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Game
{
    public interface IInputEvent
    {
        public ConsoleKey Key { get; set; }
        public bool IsHandled { get; set; }
        public IGameState GameState { get; set; }
    }
}
