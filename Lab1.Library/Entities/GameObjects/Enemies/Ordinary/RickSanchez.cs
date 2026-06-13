using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Enemies.Cowardly;
using Lab1.Library.Interfaces.Entities.GameObjects.Enemies;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services;
using Lab1.Library.Entities.Main.EnemyMovement;

namespace Lab1.Library.Entities.GameObjects.Enemies.Ordinary
{
    public class RickSanchez(Point pos) : Enemy(pos), IOrdinary
    {
        private int _health = 40;
        public override int Health 
        { 
            get => _health; 
            set 
            { 
                _health = value;


                if(_health >= 40)
                {
                    _movementState = new RandomMovementState();
                }
                else if (_health >= 20 && _health < 40)
                {
                    _movementState = new AggressiveMovementState();
                }
                else if (_health > 0 && _health < 20)
                {
                    _movementState = new CowardlyMovementState();
                }
                else
                {
                    _movementState = new RandomMovementState();
                }
            } 
        } 
        public override int Damage { get; set; } = 4;
        public override int Armor { get; set; } = 5;
        public override char Char { get; set; } = 'R';
        public override int SeeRange { get; set; } = 5;

        public override event Action<IDestroyable>? OnDestroyRequested;

        public override bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this); 
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
            var clone = new RickSanchez(Pos)
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

        public override bool TakeDamage(int damage)
        {
            var res = base.TakeDamage(damage);

            return res;
        }

        public override void RegisterInKillMediator(IMediatorsDirector<INoiseData, IKillData> md)
        {
            md.SubscribeKill(this);
        }
    }
}
