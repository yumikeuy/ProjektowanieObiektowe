using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main.EnemyMovement;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Enemies;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects.Enemies.Cowardly
{
    public class Robot(Point pos) : Enemy(pos, new CowardlyMovementState()), ICowardly
    {
        public override int Health { get; set; } = 40;
        public override int Damage { get; set; } = 4;
        public override int Armor { get; set; } = 5;
        public override char Char { get; set; } = '%';
        public override int SeeRange { get; set; } = 5;

        public override event Action<IDestroyable>? OnDestroyRequested;


        public override bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this); //TODO unsubscribe, die destroy
        }
        protected override void Die()
        {
            OnDestroyRequested?.Invoke(this);
            base.Die();
        }

        public override void OnNotify(IKillData killData)
        {
            Armor -= 5;
            Damage -= 5;
        }

        public override object Clone()
        {
            var clone = new Robot(Pos)
            {
                Damage = Damage,
                Char = Char,
                IsPendingDeletion = IsPendingDeletion,
                Health = Health,
                Armor = Armor,
                OnDestroyRequested = null
            };

            return clone;
        }
        public override void RegisterInKillMediator(IMediatorsDirector<INoiseData, IKillData> md)
        {
            md.SubscribeKill(this);
        }
    }
}
