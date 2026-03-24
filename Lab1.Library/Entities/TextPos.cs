using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class TextPos
    {
        public string Text { get; set; } = string.Empty;
        public Point PrintAt { get; set; }

        public TextPos(string text, Point printAt)
        {
            Text = text;
            PrintAt = printAt;
        }
        public TextPos(Point printAt)
        {
            PrintAt = printAt;
        }

        public static TextPos operator+(TextPos left, TextPos right)
        {
            if (left.PrintAt != right.PrintAt) return left;
            left.Text += right.Text;
            return left;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
