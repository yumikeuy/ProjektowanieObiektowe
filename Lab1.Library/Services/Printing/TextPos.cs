using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Services.Printing
{
    public class TextPos : ITextPos
    {
        public string Text { get; set; } = string.Empty;
        public Point PrintAt { get; }

        public TextPos(string text, Point printAt)
        {
            Text = text;
            PrintAt = printAt;
        }
        public TextPos(Point printAt)
        {
            PrintAt = printAt;
        }
    }
}
