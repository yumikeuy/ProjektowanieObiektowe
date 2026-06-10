using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services;
using Lab1.Library.Services.Validators.BoardValidators;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.Main.EnemyMovement
{
    public class RandomMovementState : IMovementState
    {
        public Point? CalculateNewPos(Point currentPos, ref Point? lastPlayerPos, IGameState gameState)
        {
            var board = gameState.Board;
            var dirs = new List<Point>();
            foreach (var p in currentPos.Neighbors)
                if (IsInsideBoardValidator.IsValid(board, p) && !board.GetAt(p).AcceptGameObjectVisitor(new CantBeGoneThrough()))
                    dirs.Add(p);

            if (dirs.Count > 0)
            {
                var newPos = dirs[Random.Shared.Next(dirs.Count)];
                return newPos;
            }

            return null;
        }
    }
}
