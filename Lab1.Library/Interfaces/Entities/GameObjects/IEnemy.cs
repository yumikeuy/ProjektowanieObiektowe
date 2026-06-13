using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Interfaces.Entities.GameObjects
{
    public interface IEnemy : IGameObject, IDestroyable, IDamagable, ICloneable, IResponsive<IKillData>, IResponsive<INoiseData>
    {
        int Health { get; set; }
        int Damage { get; set; }
        int Armor { get; set; }
        int SeeRange { get; set; }
        void Move(IGameState game);
        void RegisterInKillMediator(IMediatorsDirector<INoiseData, IKillData> md);
        void SetMovementState(IMovementState movementState);
        void SetDefaultMovementState(IMovementState movementState);
    }
}
