using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Validators.AttackValidators;
using Lab1.Library.Services.Visitors;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;
using Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors;

namespace Lab1.Library.Services.GameInstructions.Attack
{
    public abstract class AttackInstruction : ActionInstruction 
    {
        protected AttackVisitor _attackVisitor = null!;
        public override void Execute(IInputEvent inputEvent)
        {
            var board = inputEvent.GameState.Board;
            var player = inputEvent.GameState.Player;
            var mediators = inputEvent.GameState.MediatorsDirector;
            var item = player.State.GetCurrentItem();
            int damage = 0;
            int armor = 0;

            if (item != null)
            {
                item.AcceptItemVisitor(_attackVisitor);
                damage = _attackVisitor.CalculatedDamage;
                armor = _attackVisitor.CalculatedArmor;
            }

            if (NearEnemyValidator.IsValid(board, player, out var gameObject))
            {
                var takeDamageVisitor = new TakeDamage(damage);
                if (gameObject.AcceptGameObjectVisitor(takeDamageVisitor))
                {
                    Logger.Instance.Log($"Attacked an enemy with {damage} damage.");
                    var enemy = (IEnemy)gameObject;
                    player.State.Armor = armor;
                    if (!takeDamageVisitor.HasDied)
                        enemy.AcceptGameObjectVisitor(new RespondWithAttack(player));
                    else
                        enemy.AcceptGameObjectVisitor(new KillNotify(mediators, enemy.Pos));
                }
            }

            base.Execute(inputEvent);
        }
    }
}
