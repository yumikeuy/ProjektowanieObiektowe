using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.Game
{
    public interface IMovementValidator
    {
        public bool IsValid(IBoard board, Point nextPos);
    }
}
