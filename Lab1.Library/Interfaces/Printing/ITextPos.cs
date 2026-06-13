using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.Printing
{
    public interface ITextPos
    {
        public string Text { get; set; }
        public Point PrintAt { get; }
    }
}
