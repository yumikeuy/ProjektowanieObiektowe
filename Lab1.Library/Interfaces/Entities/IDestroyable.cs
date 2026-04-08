using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IDestroyable
    {
        event Action<IDestroyable> OnDestroyRequested;
        bool IsPendingDeletion { get; }
        public Point Pos { get; set; }
    }
}
