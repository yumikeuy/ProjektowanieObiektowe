using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class DropItemInstruction : IActionInstruction
    {
        public ICollection<char> Chars { get; set; } = ['Q'];
        public ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.Q];
        public string Description { get; set; } = "Press \"Q\" to drop item from current hand";
        public Action<IGameState, ConsoleKey> Action { get; set; } = (gs, k) => gs.Board.TryDrop(gs.Player);
    }
}
