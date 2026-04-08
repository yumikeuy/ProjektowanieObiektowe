using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IPlayer : IGameObject, IDestroyable
    {
        public IPlayerState State { get; set; }
        public void TakeDamage(int damage);
    }
}
