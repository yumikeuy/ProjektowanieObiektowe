using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameObjects.Money
{
    public abstract class Money(Point pos) : GameObject(pos), IPickable
    {
        public override bool Pickable()
        {
            return true;
        }
    }
}
