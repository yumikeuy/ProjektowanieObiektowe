using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IBoard : ITextConvertible
    {
        int Width { get; }
        int Height { get; }
        string IntroductionText { get; set; }
        ICollection<Point> GetEmptyCells();
        Point GetSpawnPoint();
        IGameObject GetAt(Point pos);
        void SetAt(Point pos, IGameObject gameObject);
        Point GetZero();
        bool IsReachable(Point src, Point dst, int radius, out int dist);
        bool HasChanged { get; set; }
        BoardChanges FlushChanges();
    }
}
