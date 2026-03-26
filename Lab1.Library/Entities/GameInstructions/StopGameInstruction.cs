using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class StopGameInstruction : IActionInstruction
    {
        public ICollection<char> Chars { get; set; } = [];
        public ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.Escape];
        public string Description { get; set; } = "Press \"Escape\" to exit the game";
        public Action<IInputEvent> Action { get; set; } = (ie) => ie.GameState.IsActive = false;
    }
}
