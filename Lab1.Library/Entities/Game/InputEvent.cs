using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Entities.Game
{
    public class InputEvent(IGame Game, ConsoleKey key, IPlayer player) : IInputEvent
    {
        public bool IsHandled { get; set; } = false;
        public IGame Game { get; set; } = Game;
        public ConsoleKey Key { get; set; } = key;
        public IPlayer Player { get; set; } = player;
    }
}
