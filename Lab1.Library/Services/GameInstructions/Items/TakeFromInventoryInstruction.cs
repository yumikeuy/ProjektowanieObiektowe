using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.GameInstructions;

namespace Lab1.Library.Services.GameInstructions.Items
{
    public class TakeFromInventoryInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['1', '2', '3', '4', '5'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5];
        public override string Description { get; set; } = "Press k to take the k-th item";
        public override void Execute(IInputEvent inputEvent)
        {
            inputEvent.GameState.Player.State.TryTakeItemToHand(inputEvent.Key - ConsoleKey.D1);
            base.Execute(inputEvent);
        }
    }
}
