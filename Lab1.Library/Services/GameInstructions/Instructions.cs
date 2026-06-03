using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Game;
using Lab1.Library.Entities.Printing;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.InputHandlers;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Services.GameInstructions
{
    public class Instructions(Point printAt) : IInstructions
    {
        private InputHandler _handler = null!;
        public Point PrintAt { get; set; } = printAt;
        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos("Controls: ", PrintAt));
            p.Add(new EmptyLine(PrintAt.Down, 10).Text());
            int i = 1;
            var handler = _handler;
            while (handler != null)
            {
                foreach (var instruction in handler.GetInstructions())
                {
                    p.AddText(new TextPos(instruction.Description, PrintAt.DownN(i++)));
                    p.Add(new EmptyLine(PrintAt.DownN(i++), 10).Text());
                }
                handler = handler.GetNext();
            }

            return p;
        }

        public void AddHandler(InputHandler handler)
        {
            if (_handler == null)
                _handler = handler;
            else
                _handler.SetNext(handler);
        }

        public void ExecuteAction(IGame game, ConsoleKey key, IPlayer player)
        {
            _handler.Handle(new InputEvent(game, key, player));
        }
    }
}
