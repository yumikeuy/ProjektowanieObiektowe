using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces
{
    public interface IInstructions : ITextConvertible
    {
        public void AddHandler(InputHandler handler);
        public InputHandler GetHandler();
        public void ExecuteAction(IGameState gameState, ConsoleKey key);
    }
}
