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
        private InputHandler _handler = null!;
        public Point PrintAt { get; set; } = printAt;
        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos("Controls: ", PrintAt));
            p.Add(new EmptyLine(new(PrintAt.X, PrintAt.Y + 1), 10).Text());
            int i = 1;
            var handler = _handler;
            while(handler != null)
            {
                foreach (var instruction in handler.GetInstructions())
                {
                    p.AddText(new TextPos(instruction.Description, new(PrintAt.X, PrintAt.Y + i++)));
                    p.Add(new EmptyLine(new(PrintAt.X, PrintAt.Y + i++), 10).Text());
                }
                handler = handler.GetNext();
            }

            return p;
        }

        public void AddHandler(InputHandler handler)
        {
            if(_handler == null)
                _handler = handler;
            else
                _handler.SetNext(handler);
        }

        public InputHandler GetHandler()
        {
            return _handler;
        }

        public void ExecuteAction(IGameState gameState, ConsoleKey key)
        {
            _handler.Handle(new InputEvent(gameState, key));
        }
    }
}
