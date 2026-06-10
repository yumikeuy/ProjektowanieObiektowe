using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services;
using Lab1.Library.Services.Validators.BoardValidators;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.Main.EnemyMovement
{
    public class CowardlyMovementState() : IMovementState
    {
        private Point? lastVisited;

        public Point? CalculateNewPos(Point currentPos, ref Point? lastPlayerPos, IGameState gameState)
        {
            Point? pos;
            var board = gameState.Board;

            if(lastPlayerPos == null)
            {
                return null;
            }

            var dirs = new List<Point>();
            foreach (var p in currentPos.Neighbors)
            {
                if (IsInsideBoardValidator.IsValid(board, p) && !board.GetAt(p).AcceptGameObjectVisitor(new CantBeGoneThrough()))
                {
                    if((p - (Point)lastPlayerPos).Abs >= (currentPos - (Point)lastPlayerPos).Abs)
                        dirs.Add(p);
                }
            }

            if (dirs.Count > 0)
            {
                pos = dirs[Random.Shared.Next(dirs.Count)];
            }
            else
            {
                lastPlayerPos = null;
                return null;
            }

            if (pos != lastVisited)
            {
                lastVisited = pos;
            }
            else
            {
                lastPlayerPos = null;
            }

            return pos;
        }
    }
}
