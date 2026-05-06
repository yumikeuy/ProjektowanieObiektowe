using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.EventsMediators.Noise;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Validators.BoardValidators;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects.Enemies
{
    public abstract class Enemy(Point pos) : IEnemy
    {
        public abstract int Health { get; set; } 
        public abstract int Damage { get; set; }
        public abstract int Armor { get; set; } 
        public abstract char Char { get; set; }
        
        public virtual Point PrintAt { get; set; } = pos;
        public virtual Point Pos { get; set; } = pos;
        public virtual Point? CurrentDestination { get; set; } = null;

        public virtual bool IsPendingDeletion { get; set; } = false;
        public abstract event Action<IDestroyable>? OnDestroyRequested;

        public abstract bool AcceptGameObjectVisitor(GameObjectVisitor visitor);

        public bool TakeDamage(int damage)
        {
            var actualDamage = damage - Armor;
            if (actualDamage < 0) actualDamage = 0;

            Health -= actualDamage - Armor;

            if (Health <= 0)
            {
                Die();
                return true;
            }

            return false;
        }
        protected virtual void Die()
        {
            IsPendingDeletion = true;
            Logger.Instance.Log("Killed an enemy.");
        }

        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), PrintAt));
            return p;
        }

        public void OnNotify(INoiseData noiseData)
        {
            if (noiseData.CanHear(Pos, out var dist))
            {
                CurrentDestination = noiseData.Source;
                Logger.Instance.Log($"An enemy at ({Pos.X}, {Pos.Y}) heard a noise in {dist} tales," +
                    $"coming from ({noiseData.Source.X}, {noiseData.Source.Y}). It was {noiseData.Description.ToLower()}.");
            }
        }

        public virtual void OnNotify(IKillData killData)
        {
            Armor += 5;
            Damage += 5;
        }

        public abstract object Clone();
        public void Move(IBoard board)
        {
            var dirs = new List<Point>();
            foreach(var p in Pos.Neighbors)
                if (IsInsideBoardValidator.IsValid(board, p) && !board.GetAt(p).AcceptGameObjectVisitor(new CantBeGoneThrough()))
                    dirs.Add(p);
            if(dirs.Count > 0)
            {
                var newPos = dirs[Random.Shared.Next(dirs.Count - 1)];
                board.SetAt(newPos, this);
                board.SetAt(Pos, new EmptyGameObject());
                Pos = PrintAt = newPos;
            }            
        }

        public abstract void RegisterInKillMediator(IMediatorsDirector<INoiseData, IKillData> md);
    }
}
