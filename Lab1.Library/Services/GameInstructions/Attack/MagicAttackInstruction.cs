using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Game;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors;

namespace Lab1.Library.Services.GameInstructions.Attack
{
    public class MagicAttackInstruction : AttackInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['C'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.C];
        public override string Description { get; set; } = "Press \"C\" to use magic attack on an enemy";
        public override void Execute(IInputEvent inputEvent)
        {
            _attackVisitor = new MagicAttackVisitor(inputEvent.GameState.Player.State);
            
            base.Execute(inputEvent);
        }
    }
}
