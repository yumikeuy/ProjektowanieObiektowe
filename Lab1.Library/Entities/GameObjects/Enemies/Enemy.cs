using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Game;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Entities.Main;
using Lab1.Library.Entities.Main.EnemyMovement;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;
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
        public virtual int SeeRange { get; set; } = 5;

        private Point? lastPlayerPos;

        protected IMovementState _movementState = new RandomMovementState();
        protected IMovementState _defaultMovementState = new RandomMovementState();

        public void SetMovementState(IMovementState movementState)
        {
            _movementState = movementState;
        }

        public void SetDefaultMovementState(IMovementState movementState)
        {
            _defaultMovementState = movementState;
        }

        public virtual bool IsPendingDeletion { get; set; } = false;
        public abstract event Action<IDestroyable>? OnDestroyRequested;

        public abstract bool AcceptGameObjectVisitor(GameObjectVisitor visitor);

        public Enemy(Point pos, IMovementState movementState) : this(pos)
        {
            _movementState = movementState;
        }

        public virtual bool TakeDamage(int damage)
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
                lastPlayerPos = noiseData.Source;
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

        public void Move(IGameState gs)
        {
            var board = gs.Board;

            LookForPlayer(Pos, gs);

            var newPos = _movementState.CalculateNewPos(Pos, ref lastPlayerPos, gs);
            newPos ??= _defaultMovementState.CalculateNewPos(Pos, ref lastPlayerPos, gs);

            if (newPos != null)
            {
                GoTo((Point)newPos, board);
            }
        }

        private void GoTo(Point newPos, IBoard board)
        {
            if (newPos == Pos) return;

            board.Swap(Pos, newPos);
            Pos = newPos;
        }

        public abstract void RegisterInKillMediator(IMediatorsDirector<INoiseData, IKillData> md);


        private void LookForPlayer(Point currentPos, IGameState gs)
        {
            var board = gs.Board;
            var playerManager = gs.PlayerManager;

            var points = new List<Point>();

            foreach (var p in currentPos.Neighbors)
            {
                var dir = p - currentPos;

                for (int i = 0; i < SeeRange; i++)
                {
                    if (IsInsideBoardValidator.IsValid(board, p) && !board.GetAt(p).AcceptGameObjectVisitor(new CantBeGoneThrough()))
                        points.Add(currentPos + i * dir);
                    else
                        i = SeeRange;
                }
            }

            Point? playerPos = null;

            foreach (var p in points)
            {
                if (playerManager.GetPlayer(p) != null)
                {
                    playerPos = p;
                    break;
                }
            }

            if (playerPos != null)
            {
                lastPlayerPos = playerPos;
            }
        }
    }
}
