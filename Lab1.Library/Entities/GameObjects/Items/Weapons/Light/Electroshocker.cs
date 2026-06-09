using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.LightWeapons;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Light
{
    public class Electroshocker : ILightWeapon
    {
        public int Damage { get; set; } = 2;
        public char Char { get; set; } = 'z';
        public bool IsTwoHanded { get; set; } = true;
        public string Description { get; set; } = "Electroshocker";
        public Point PrintAt { get; set; } = (0, 0);

        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public bool AcceptItemVisitor(ItemVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public void Activate(IPlayerState playerState)
        {
            playerState.Damage += Damage;
        }
        public void Deactivate(IPlayerState playerState)
        {
            playerState.Damage -= Damage;
        }
        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), PrintAt));
            return p;
        }
    }
}
