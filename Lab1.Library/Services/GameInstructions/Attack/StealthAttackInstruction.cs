using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Services.GameInstructions.Attack
{
    public class StealthAttackInstruction : AttackInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['B'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.B];
        public override string Description { get; set; } = "Press \"B\" to use stealth attack on an enemy";
        public override void Execute(IInputEvent inputEvent)
        {
            _damage = inputEvent.GameState.Player.State.Damage;



            base.Execute(inputEvent);
            throw new NotImplementedException();
        }
    }
}
