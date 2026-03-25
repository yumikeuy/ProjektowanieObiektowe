using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;

namespace Lab1.Library.Entities.GameInstructions
{
    public class Instructions(Point printAt) : IInstructions
    {
        private HashSet<IActionInstruction> _instructions { get; set; } = [];
        public Point PrintAt { get; set; } = printAt;
        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos("Controls: ", PrintAt));
            p.Add(new EmptyLine(new(PrintAt.X, PrintAt.Y + 1), 10).Text());
            int i = 1;
            foreach(var instruction in _instructions)
            {
                p.AddText(new TextPos(instruction.Description, new(PrintAt.X, PrintAt.Y + i++)));
                p.Add(new EmptyLine(new(PrintAt.X, PrintAt.Y + i++), 10).Text());
            }


            return p;
        }

        public void Add(IActionInstruction instruction)
        {
            _instructions.Add(instruction);
        }

        public HashSet<IActionInstruction> GetActions()
        {
            return _instructions;
        }

        public void ExecuteAction(IGameState gameState, ConsoleKey key)
        {
            _instructions.First(i => i.Keys.Contains(key)).Action(gameState, key);
        }
    }
}
