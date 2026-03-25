using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IBoardInitializer
    {
        public IBoard InitializeEmpty(int width, int height, IPlayer player);
        public IBoard InitializeFull(int width, int height, IPlayer player);
        public IBoard DefaultInitialize(int width, int height, IPlayer player);
    }
}
