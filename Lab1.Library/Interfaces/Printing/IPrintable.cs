using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.Printing
{
    public interface IPrintable
    {
        public Point LastPosition { get; }

        public void Print();
        public void AddText(ITextPos txt);
        public void RemoveText(ITextPos txt);
        public string GetText();
        public IPrintable Add(IPrintable printable);
        public ICollection<ITextPos> GetData();
    }
}
