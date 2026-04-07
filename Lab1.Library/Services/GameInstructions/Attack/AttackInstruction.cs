using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Validators.AttackValidators;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Services.GameInstructions.Attack
{
    public abstract class AttackInstruction : ActionInstruction 
    {
        protected int _damage;
        public override void Execute(IInputEvent inputEvent)
        {
            var board = inputEvent.GameState.Board;
            var player = inputEvent.GameState.Player;
            if(NearEnemyValidator.IsValid(board, player, out var gameObject))
            {
                if(gameObject.Accept(new TakeDamage(_damage)))
                {
                    //TODO
                }
            }
            base.Execute(inputEvent);
        }
    }
}
