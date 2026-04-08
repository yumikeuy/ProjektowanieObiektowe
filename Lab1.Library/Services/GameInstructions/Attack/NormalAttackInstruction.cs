using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Game;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.GameInstructions;
using Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors;

namespace Lab1.Library.Services.GameInstructions.Attack
{
    public class NormalAttackInstruction : AttackInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['X'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.X];
        public override string Description { get; set; } = "Press \"X\" to use normal attack on an enemy";
        public override void Execute(IInputEvent inputEvent)
        {
            var attackVisitor = new NormalAttackVisitor();
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
