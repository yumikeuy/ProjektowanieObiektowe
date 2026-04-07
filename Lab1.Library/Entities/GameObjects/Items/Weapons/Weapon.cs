using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public abstract class Weapon : Item
    {
        protected virtual int Damage { private get; set; }

        public override void Activate(IPlayerState playerState)
        {
            base.Activate(playerState);
            playerState.Damage += Damage;
        }
        public override void Deactivate(IPlayerState playerState)
        {
            base.Activate(playerState);
            playerState.Damage -= Damage;
        }
        public override bool Accept(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
