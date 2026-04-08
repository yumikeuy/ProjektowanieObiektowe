using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.Game
{
    public interface IDestroyer
    {
        public void Add(IDestroyable entity);
        public void CleanUp();
    }
}
