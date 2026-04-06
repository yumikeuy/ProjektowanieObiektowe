using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Enemies
{
    public abstract class Enemy : GameObject
    {
        //TODO
        public override char Char { get; set; } = '#';
    }
}
