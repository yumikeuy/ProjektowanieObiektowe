using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IBoardBuilder
    {
        public IBoardBuilder InitializeEmpty(int width, int height);
        public IBoardBuilder InitializeFull(int width, int height);
        public IBoardBuilder AddCorridors();
        public IBoardBuilder AddRooms();
        public IBoardBuilder AddCentralRoom();
        public IBoardBuilder AddItems();
        public IBoardBuilder AddWeapons();
        public IBoard GetResult();
    }
}
