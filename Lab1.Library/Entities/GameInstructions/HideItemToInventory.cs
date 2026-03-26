using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class HideItemToInventory : IActionInstruction
    {
        public ICollection<char> Chars { get; set; } = ['0'];
        public ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.D0];
        public string Description { get; set; } = "Press \"0\" to put item to inventory";
        public Action<IInputEvent> Action { get; set; } = (ie) => ie.GameState.Player.State.TryHideItem();
    }
}
