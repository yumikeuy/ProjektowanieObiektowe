using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Visitors;
using Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors;

namespace Lab1.Library.Services.GameInstructions.Attack
{
    public class StealthAttackInstruction : AttackInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['B'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.B];
        public override string Description { get; set; } = "Press \"B\" to use stealth attack on an enemy";
        public override void Execute(IInputEvent inputEvent)
        {
            var attackVisitor = new StealthAttackVisitor();
            var item = inputEvent.GameState.Player.State.GetCurrentItem();

            if (item != null)
            {
                item.AcceptItemVisitor(attackVisitor);
                _damage = attackVisitor.CalculatedDamage;
            }
               
            base.Execute(inputEvent);
        }
    }
}
