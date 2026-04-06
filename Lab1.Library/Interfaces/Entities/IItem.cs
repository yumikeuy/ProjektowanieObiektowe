using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IItem : IGameObject
    {
        public bool IsTwoHanded { get; set; }
        public string Description { get; set; }

        public abstract void Activate(IPlayerState playerState);
        public abstract void Deactivate(IPlayerState playerState);
    }
}
