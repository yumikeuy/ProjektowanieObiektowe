using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces
{
    public interface IPrintable
    {
        public Point LastPosition { get; }

        public void Print();
        public void AddText(TextPos txt);
        public void RemoveText(TextPos txt);
        public string ToString();
        public IPrintable Add(IPrintable printable);
        public ICollection<TextPos> GetData();
    }
}
