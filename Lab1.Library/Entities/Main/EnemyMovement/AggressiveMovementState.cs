using System;
using System.Collections.Generic;
using System.IO;
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
    public class AggressiveMovementState() : IMovementState
    {
        private Point? lastVisited;
        private Point? lastDest;
        private Stack<Point> path = [];

        public Point? CalculateNewPos(Point currentPos, ref Point? lastPlayerPos, IGameState gameState)
        {
            var board = gameState.Board;


            if (lastPlayerPos == currentPos)
            {
                lastPlayerPos = null;
            }

            if (lastPlayerPos == null)
            {
                return null;
            }

            if (Point.IsNear(currentPos, (Point)lastPlayerPos))
            {
                var nearPlayer = gameState.PlayerManager.GetPlayer((Point)lastPlayerPos);

                if(nearPlayer != null)
                {
                    board.GetAt(currentPos).AcceptGameObjectVisitor(new RespondWithAttack(nearPlayer));
                    return currentPos;
                }
            }

            Point? pos = null;

            if (lastDest == lastPlayerPos)
            {
                if (path.Count > 0)
                {
                    pos = path.Pop();
                }
            }
            else
            {
                lastDest = lastPlayerPos;
                var newPath = board.FindPath(currentPos, (Point)lastPlayerPos);
                newPath.Reverse();
                path = new Stack<Point>(newPath);
                path.Pop();
                pos = path.Pop();
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
