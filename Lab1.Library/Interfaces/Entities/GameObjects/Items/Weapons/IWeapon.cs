using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons
{
    public interface IWeapon : IItem
    {
        public int Damage { get; set; }
    }
}
