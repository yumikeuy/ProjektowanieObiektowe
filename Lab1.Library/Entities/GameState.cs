using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;

namespace Lab1.Library.Entities
{
    public class GameState : IGameState
    {
        public bool IsActive { get; set; } = false;
        public IPlayer Player { get; set; } = null!;
        public IInstructions Instructions { get; set; } = null!;
        public IBoard Board { get; set; } = null!;
        public IPrinter Printer { get; set; } = null!;

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
