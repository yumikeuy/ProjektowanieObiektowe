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
            _attackVisitor = new NormalAttackVisitor(inputEvent.GameState.Player.State);

            base.Execute(inputEvent);
        }
    }
}
