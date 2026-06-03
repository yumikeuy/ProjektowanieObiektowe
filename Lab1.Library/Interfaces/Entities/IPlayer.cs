using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IPlayer : IGameObject, IDestroyable, IDamagable
    {
        public IPlayerState State { get; set; }
        public IPEndPoint IP { get; set; }
        public string Name { get; set; }
        void Die();
    }
}
