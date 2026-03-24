using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;

namespace Lab1.Library.Interfaces
{
    public interface ITextConvertible
    {
        public Point PrintAt { get; set; }
        public Printable Text();
    }
}
