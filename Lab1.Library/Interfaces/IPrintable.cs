using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IPrintable
    {
        public int[] PrintAt {  get; set; }
        public void Print();
    }
}
