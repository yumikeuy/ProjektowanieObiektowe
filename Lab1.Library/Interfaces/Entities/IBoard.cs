using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IBoard : ITextConvertible
    {
        public int Width { get; }
        public int Height { get; }
        public string IntroductionText { get; set; }
        public bool TryPickUp(IPlayer player);
        public bool TryDrop(IPlayer player);
        public ICollection<Point> GetEmptyCells();
        public Point GetSpawnPoint();
        public IGameObject GetAt(Point pos);
        public void SetAt(Point pos, IGameObject gameObject);
        public Point GetZero();
    }
}
