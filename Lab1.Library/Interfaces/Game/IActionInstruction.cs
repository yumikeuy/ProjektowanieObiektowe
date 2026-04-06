using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Game
{
    public interface IActionInstruction
    {
        public ICollection<char> Chars { get; set; }
        public ICollection<ConsoleKey> Keys { get; set; }
        public string Description { get; set; }
        public Action<IInputEvent> Action { get; set; }
    }
}
