using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Services
{
    public class Printable : IPrintable
    {
        private ICollection<TextPos> _data = [];
        public Point LastPosition => _data.Last().PrintAt;

        public void Print()
        {
            var (Left, Top) = Console.GetCursorPosition();
            foreach (var txt in _data)
            {
                Console.SetCursorPosition(txt.PrintAt.X, txt.PrintAt.Y);
                Console.Write(txt);
            }
            Console.SetCursorPosition(Left, Top);
        }
        public void AddText(TextPos txt)
        {
            _data.Add(txt);
        }
        public void RemoveText(TextPos txt)
        {
            _data.Remove(txt);
        }
        public override string ToString()
        {
            string res = string.Empty;

            foreach (var txt in _data)
                res += txt.Text;

            return res;
        }
        public IPrintable Add(IPrintable printable)
        {
            foreach(var txt in printable.GetData())
            {
                _data.Add(txt);
            }

            return this;
        }
        public ICollection<TextPos> GetData()
        {
            return _data;
        }
    }
}
