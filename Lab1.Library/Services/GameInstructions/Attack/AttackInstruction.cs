using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Services.GameInstructions.Attack
{
    public abstract class AttackInstruction : ActionInstruction 
    {
        public override void Execute(IInputEvent inputEvent)
        {
            //inputEvent.GameState.Board.TryAttack(inputEvent.GameState.Player);
            base.Execute(inputEvent);
        }
    }
}
