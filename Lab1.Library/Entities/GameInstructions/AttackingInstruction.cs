using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Entities.GameInstructions
{
    public class AttackingInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['X'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.X];
        public override string Description { get; set; } = "Press \"X\" to attack an enemy";
        public override void Execute(IInputEvent inpuEvent)
        {
            //TODO
            throw new NotImplementedException();
            base.Execute(inpuEvent);
        }
    }
}
