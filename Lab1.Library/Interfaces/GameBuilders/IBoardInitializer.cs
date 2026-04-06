using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.GameBuilders
{
    public interface IBoardInitializer
    {
        public IBoard InitializeEmpty(int width, int height);
        public IBoard InitializeFull(int width, int height);
        public IBoard DefaultInitialize(int width, int height);
    }
}
