using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IGame
    {
        IGameState GameState { get; set; }
        IPrinter Printer { get; set; }
        IInstructions Instructions { get; set; }
    }
}
