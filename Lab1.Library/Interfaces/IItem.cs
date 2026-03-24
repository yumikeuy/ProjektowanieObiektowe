using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IItem : IGameObject
    {
        public bool IsTwoHanded { get; set; }
        public string Description { get; set; }
    }
}
