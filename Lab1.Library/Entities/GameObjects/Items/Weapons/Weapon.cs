using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public abstract class Weapon : Item
    {
        public int Damage { get; set; }

        public override void Activate(IPlayerState playerState)
        {
            playerState.Damage += Damage;
        }
        public override void Deactivate(IPlayerState playerState)
        {
            playerState.Damage -= Damage;
        }
        public override bool AcceptItemVisitor(ItemVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
