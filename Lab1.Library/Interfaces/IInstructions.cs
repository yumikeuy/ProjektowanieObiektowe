using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IInstructions : ITextConvertible
    {
        public void Add(IActionInstruction instruction);
        public HashSet<IActionInstruction> GetActions();
        public void ExecuteAction(IGameState gameState, ConsoleKey key);
    }
}
