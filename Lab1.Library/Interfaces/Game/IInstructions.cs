using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services.InputHandlers;

namespace Lab1.Library.Interfaces.Game
{
    public interface IInstructions : ITextConvertible
    {
        public void AddHandler(InputHandler handler);
        public InputHandler GetHandler();
        public void ExecuteAction(IGameState gameState, ConsoleKey key);
    }
}
