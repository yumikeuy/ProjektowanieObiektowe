using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class PickUpInstruction : IActionInstruction
    {
        public ICollection<char> Chars { get; set; } = ['E'];
        public ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.E];
        public string Description { get; set; } = "Press \"E\" to pick up the item";
        public Action<IGameState, ConsoleKey> Action { get; set; } = (gs, k) => gs.Board.TryPickUp(gs.Player);

    }
}
