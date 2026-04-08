using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors
{
    public abstract class AttackVisitor : ItemVisitor
    {
        public virtual int CalculatedDamage { get; set; }
        public virtual int CalculatedArmor { get; set; }
    }
}
