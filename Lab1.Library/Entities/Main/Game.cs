using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Entities.Main
{
    public class Game : IGame
    {
        public IGameState GameState { get; set; }
        public IPrinter Printer { get; set; }
        public IInstructions Instructions { get; set; }

        public Game(IGameState gameState, IPrinter printer, IInstructions instructions)
        {
            GameState = gameState;
            Printer = printer;
            Instructions = instructions;
        }
    }
}
