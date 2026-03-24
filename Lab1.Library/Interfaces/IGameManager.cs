using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities;

namespace Lab1.Library.Interfaces
{
    public interface IGameManager
    {
        public void StartGame();
        public void StopGame();
    }
}
