using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class TakeFromInventoryInstruction : IActionInstruction
    {
        public ICollection<char> Chars { get; set; } = ['1', '2', '3', '4', '5'];
        public ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5];
        public string Description { get; set; } = "Press k to take the k-th item";
        public Action<IInputEvent> Action { get; set; } = (ie) => ie.GameState.Player.State.TryTakeItemToHand(ie.Key - ConsoleKey.D1);
    }
}
