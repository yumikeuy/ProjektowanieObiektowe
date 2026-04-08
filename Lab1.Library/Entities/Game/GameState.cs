using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Entities.Game
{
    public class GameState : IGameState
    {
        public bool IsActive { get; private set; } = false;
        public IPlayer Player { get; set; } = null!;
        public IInstructions Instructions { get; set; } = null!;
        public IBoard Board { get; set; } = null!;
        public IPrinter Printer { get; set; } = null!;
        public IDestroyer Destroyer { get; set; } = null!;
        public string EndReason { get; private set; } = string.Empty;

        public void Stop(string reason)
        {
            IsActive = false;
            EndReason = reason;
        }

        public void Start()
        {
            IsActive = true;
        }

        public Point PrintAt { get; set; } = new(0, 0);
        public IPrintable Text()
        {
            Printable p = new();

            p.Add(Board.Text());
            p.Add(Player.Text());
            p.Add(Player.State.Text());
            p.Add(Instructions.Text());

            return p;
        }
    }
}
