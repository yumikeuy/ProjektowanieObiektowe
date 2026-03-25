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
    public class PressELine : ITextConvertible
    {
        public Point PrintAt { get; set; }
        private const string pressELine = "Press \"E\" to pick up.";

        public PressELine(Point printAt)
        {
            PrintAt = printAt;
        }

        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(pressELine, PrintAt));
            return p;
        }
    }
}
