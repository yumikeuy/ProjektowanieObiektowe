using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;

namespace Lab1.Library.Interfaces
{
    public interface IHand : ITextConvertible
    {
        public bool TryAdd(IItem item);
        public IItem? Remove();
    }
}
