using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Game
{
    public interface IGameState : ITextConvertible
    {
        public bool IsActive { get; set; }
        public IPlayer Player { get; set; }
        public IInstructions Instructions { get; set; }
        public IBoard Board { get; set; }
        public IPrinter Printer { get; set; }
        public IDestroyer Destroyer { get; set; }
    }
}
