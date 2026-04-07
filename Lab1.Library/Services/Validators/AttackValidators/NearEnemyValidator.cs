using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Extensions.PointExtensions;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Validators.BoardValidators;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Services.Validators.AttackValidators
{
    public static class NearEnemyValidator
    {
        public static bool IsValid(IBoard board, IPlayer player, out IGameObject go)
        {
            var pos = player.Pos;
            Point orientedPos = player.State.Orientation switch
            {
                'U' => pos.Up(),
                'D' => pos.Down(),
                'L' => pos.Left(),
                'R' => pos.Right(),
                _ => new(-1, -1)
            };

            if (IsInsideBoardValidator.IsValid(board, orientedPos) && board.GetAt(orientedPos).Accept(new IsEnemy()))
            {
                go = board.GetAt(orientedPos);
                return true;
            }

            foreach(var p in pos.NearPoints())
            {
                if(IsInsideBoardValidator.IsValid(board, p) && board.GetAt(p).Accept(new IsEnemy()))
                {
                    go = board.GetAt(p);
                    return true;
                }
            }


            go = null!;
            return false;
        }
    }
}
