using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Entities
{
    public class Printable
    {
        private List<TextPos> _data = [];
        public Point LastPosition => _data[_data.Count - 1].PrintAt;

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

            foreach(var txt in _data)
                res += txt.Text;

            return res;
        }

        public static Printable operator +(Printable left, Printable right)
        {
            left._data.AddRange(right._data);
            return left;
        }


    }
}
