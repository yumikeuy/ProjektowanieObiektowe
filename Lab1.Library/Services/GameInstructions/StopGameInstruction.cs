using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Services.GameInstructions
{
    public class StopGameInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = [];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.Escape];
        public override string Description { get; set; } = "Press \"Escape\" to exit the game";
        public override void Execute(IInputEvent inputEvent)
        {
            inputEvent.GameState.Stop("You exited the game.");
            base.Execute(inputEvent);
        }
    }
}
