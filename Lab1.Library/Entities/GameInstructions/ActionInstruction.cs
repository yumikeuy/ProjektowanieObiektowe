using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Entities.GameInstructions
{
    public abstract class ActionInstruction
    {
        public abstract ICollection<char> Chars { get; set; }
        public abstract ICollection<ConsoleKey> Keys { get; set; }
        public abstract string Description { get; set; }
        public virtual void Execute(IInputEvent inputEvent)
        {
            inputEvent.IsHandled = true;
        }
    }
}
