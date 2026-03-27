using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class DropItemInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['Q'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.Q];
        public override string Description { get; set; } = "Press \"Q\" to drop item from current hand";
        public override void Execute(IInputEvent inpuEvent)
        {
            inpuEvent.GameState.Board.TryDrop(inpuEvent.GameState.Player);
            base.Execute(inpuEvent);
        }
    }
}
