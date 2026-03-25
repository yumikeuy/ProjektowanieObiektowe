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
    public class EmptyLine : ITextConvertible
    {
        public Point PrintAt { get; set; }
        private readonly int _lenght;

        public EmptyLine(Point printAt, int lenght)
        {
            PrintAt = printAt;
            _lenght = lenght;
        }

        public IPrintable Text()
        {
            Printable p = new();
            var emptyLine = new string(' ', _lenght);
            p.AddText(new TextPos(emptyLine, PrintAt));
            return p;
        }
    }
}
