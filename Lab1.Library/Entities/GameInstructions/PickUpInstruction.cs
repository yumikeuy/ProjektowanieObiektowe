using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Entities.GameInstructions
{
    public class PickUpInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['E'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.E];
        public override string Description { get; set; } = "Press \"E\" to pick up the item";
        public override void Execute(IInputEvent inputEvent)
        {
            inputEvent.GameState.Board.TryPickUp(inputEvent.GameState.Player);
            base.Execute(inputEvent);
        }

    }
}
