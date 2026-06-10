using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.MagicWeapons;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Magic
{
    public class EnchantedRing : IMagicWeapon
    {
        public int Damage { get; set; } = 6;
        public char Char { get; set; } = 'q';
        public bool IsTwoHanded { get; set; } = false;
        public string Description { get; set; } = "Legendary enchanted ring";

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
            return new EnchantedRing
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
