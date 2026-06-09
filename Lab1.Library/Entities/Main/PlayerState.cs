using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.Inventory;
using Lab1.Library.Entities.Printing;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.Main
{
    public class PlayerState : IPlayerState
    {
        private readonly IInventory _inventory;
        private readonly IHands _hands;
        private readonly IHandInventoryTransfer _handInvTransfer;

        private int _damage, _health, _luck, _agility, _agressiveness, _iq, _coins, _gold, _armor;

        public int Damage { get => _damage; set => Set(ref _damage, value); }
        public int Health { get => _health; set => Set(ref _health, value); }
        public int Luck { get => _luck; set => Set(ref _luck, value); }
        public int Agility { get => _agility; set => Set(ref _agility, value); }
        public int Agressiveness { get => _agressiveness; set => Set(ref _agressiveness, value); }
        public int Iq { get => _iq; set => Set(ref _iq, value); }
        public int Coins { get =>_coins; set => Set(ref _coins, value); }
        public int Gold { get => _gold; set => Set(ref _gold, value); }
        public int Armor { get => _armor; set => Set(ref _armor, value); }
        public bool HasChanged { get; set; }

        public Point PrintAt { get; set; }
        private Point currentPrintPos;
        private readonly int separatorLength = 40;

        public char Orientation { get; set; } = 'D';

        public IPrintable Text()
        {
            currentPrintPos = PrintAt;
            Printable p = new();

            AddLine(p, "Player State:");
            AddLine(p, new string('=', separatorLength));

            AddLine(p, "");
            AddLine(p, $"Damage           {Damage}");
            AddLine(p, $"Health           {Health}");
            AddLine(p, $"Happiness        {Luck}");
            AddLine(p, $"Agility          {Agility}");
            AddLine(p, $"Agressiveness    {Agressiveness}");
            AddLine(p, $"Iq               {Iq}");
            AddLine(p, "");
            AddLine(p, new string('-', separatorLength));
            AddLine(p, "");
            AddLine(p, $"Coins            {Coins}");
            AddLine(p, $"Gold             {Gold}");
            AddLine(p, "");
            AddLine(p, new string('-', separatorLength));

            _hands.PrintAt = currentPrintPos;
            p.Add(_hands.Text());
            currentPrintPos = p.LastPosition;
            currentPrintPos.Y++;

            AddLine(p, new string('-', separatorLength));

            _inventory.PrintAt = currentPrintPos;
            p.Add(_inventory.Text());
            currentPrintPos = p.LastPosition;
            currentPrintPos.Y++;

            return p;
        }
        private void AddLine(IPrintable p, string str)
        {
            p.AddText(new TextPos(str, new(currentPrintPos.X, currentPrintPos.Y++)));
        }
        public bool TryAdd(IItem item)
        {
            if (_inventory.TryAdd(item))
            {
                HasChanged = true;
                return true;
            }
            else if (_hands.TryAdd(item))
            {
                HasChanged = true;
                return true;
            }

            return false;
        }
        public IItem? Drop()
        {
            var item = _hands.Remove();

            if(item != null)
            {
                HasChanged = true;
            }

            return item;
        }
        public void SelectHand(Hands hand)
        {
            _hands.SelectHand(hand);
        }
        public IHandInventoryTransfer GetInventoryTransfer()
        {
            return _handInvTransfer;
        }
        public IItem? GetCurrentItem()
        {
            return _hands.GetCurrentItem();
        }

        private void StateDefaultInit()
        {
            Damage = 0;
            Health = 100;
            Luck = 1;
            Agility = 1;
            Agressiveness = 1;
            Iq = 1;
            Coins = 0;
            Gold = 0;
            Armor = 0;
            HasChanged = true;
        }

        public IInventory GetInventory()
        {
            return _inventory;
        }
        public (IItem? left, IItem? right) GetItemsFromHands()
        {
            return _hands.GetItemsFromHands();
        }
        public bool TryAddToLeft(IItem item)
        {
            var res = _hands.TryAddToLeft(item);

            if(res == true)
            {
                HasChanged = true;
                return true;
            }

            return res;
        }
        public bool TryAddToRight(IItem item)
        {
            var res = _hands.TryAddToRight(item);

            if (res == true)
            {
                HasChanged = true;
                return true;
            }

            return res;
        }

        private void Set(ref int field, int value)
        {
            if (field != value)
            {
                field = value;
                HasChanged = true;
            }
        }

        public PlayerState(int boardWidth)
        {
            PrintAt = (boardWidth + 10, 0);
            _inventory = new Inventory.Inventory();
            _hands = new TwoHands(this);
            _handInvTransfer = new HandInventoryTransfer(_hands, _inventory);
            StateDefaultInit();
        }
    }
}
