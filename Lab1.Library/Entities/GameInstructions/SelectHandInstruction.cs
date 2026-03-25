using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class SelectHandInstruction : IActionInstruction
    {
        public ICollection<char> Chars { get; set; } = ['L', 'R'];
        public ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.L, ConsoleKey.R];
        public string Description { get; set; } = "Press \"L\" or \"R\" to select hand";
        public Action<IGameState, ConsoleKey> Action { get; set; } = (gs, k) =>
        {
            if (k == ConsoleKey.L)
                gs.Player.State.SelectHand(Hands.Left);
            else
                gs.Player.State.SelectHand(Hands.Right);
        };
    }
}
