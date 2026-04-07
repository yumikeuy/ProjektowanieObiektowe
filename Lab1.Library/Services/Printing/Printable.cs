using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Printing;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Services.Printing
{
    public class Printable : IPrintable
    {
        private ICollection<ITextPos> _data = [];
        public Point LastPosition => _data.Last().PrintAt;

        public void Print()
        {
            var (Left, Top) = Console.GetCursorPosition();

            foreach (var txt in _data)
            {
                try
                {
                    Console.SetCursorPosition(txt.PrintAt.X, txt.PrintAt.Y);
                    Console.Write(txt.Text);
                }
                catch (Exception e) { e.GetType(); }
            }

            Console.SetCursorPosition(Left, Top);
        }
        public void AddText(ITextPos txt)
        {
            _data.Add(txt);
        }
        public void RemoveText(ITextPos txt)
        {
            _data.Remove(txt);
        }
        public string GetText()
        {
            string res = string.Empty;

            foreach (var txt in _data)
                res += txt.Text;

            return res;
        }
        public IPrintable Add(IPrintable printable)
        {
            foreach (var txt in printable.GetData())
            {
                _data.Add(txt);
            }

            return this;
        }
        public ICollection<ITextPos> GetData()
        {
            return _data;
        }

        private bool IsNearEdge()
        {
            bool nearRight = Console.CursorLeft >= Console.WindowWidth - 1;
            bool nearBottom = Console.CursorTop >= Console.WindowHeight - 1;

            return nearRight || nearBottom;
        }
    }
}
