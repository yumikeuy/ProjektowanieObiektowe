using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.HeavyWeapons;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy
{
    public class MachineGun : IHeavyWeapon
    {
        public int Damage { get; set; } = 10;
        public char Char { get; set; } = '*';
        public bool IsTwoHanded { get; set; } = true;
        public string Description { get; set; } = "Enormous MachineGun";
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

        public bool TryAdd(INeutralItem item)
        {
            return false;
        }

        public INeutralItem? TryRemoveAt(int index)
        {
            return null;
        }
        public INeutralItem? TryRemove()
        {
            return null;
        }
        public object Clone()
        {
            return new MachineGun
            {
                Char = Char,
                Description = Description,
                IsTwoHanded = IsTwoHanded,
                PrintAt = PrintAt,
                Damage = Damage
            };
        }
    }
}
