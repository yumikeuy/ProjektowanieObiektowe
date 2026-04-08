using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IDestroyable
    {
        event Action<IDestroyable> OnDestroyRequested;
        bool IsPendingDeletion { get; }
        public Point Pos { get; set; }
    }
}
