using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class SelectHandInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['L', 'R'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.L, ConsoleKey.R];
        public override string Description { get; set; } = "Press \"L\" or \"R\" to select hand";
        public override void Execute(IInputEvent inputEvent)
        {
            if (inputEvent.Key == ConsoleKey.L)
                inputEvent.GameState.Player.State.SelectHand(Hands.Left);
            else
                inputEvent.GameState.Player.State.SelectHand(Hands.Right);

            base.Execute(inputEvent);
        }
    }
}
