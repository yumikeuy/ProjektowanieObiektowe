using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities
{
    public class InputEvent(IGameState GameState, ConsoleKey key) : IInputEvent
    {
        public bool IsHandled { get; set; } = false;
        public IGameState GameState { get; set; } = GameState;
        public ConsoleKey Key { get; set; } = key;
    }
}
