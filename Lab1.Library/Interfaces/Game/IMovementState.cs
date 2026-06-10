using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.Game
{
    public interface IMovementState
    {
        Point? CalculateNewPos(Point currentPos, ref Point? lastPlayerPos, IGameState gameState);
    }
}
