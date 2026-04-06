using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.GameInstructions;

namespace Lab1.Library.Services.GameInstructions.Items
{
    public class HideItemToInventory : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['0'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.D0];
        public override string Description { get; set; } = "Press \"0\" to put item to inventory";
        public override void Execute(IInputEvent inpuEvent)
        {
            inpuEvent.GameState.Player.State.TryHideItem();
            base.Execute(inpuEvent);
        }
    }
}
