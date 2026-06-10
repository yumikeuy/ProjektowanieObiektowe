using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Validators.ItemsValidators;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Services.GameInstructions.Items
{
    public class RetrieveItemFromHandle : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['I'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.I];
        public override string Description { get; set; } = "Press \"I\" to retrieve an item from handler/weapon";
        public override void Execute(IInputEvent inpuEvent)
        {
            var board = inpuEvent.Game.GameState.Board;
            var player = inpuEvent.Player;
            var ps = inpuEvent.Player.State;

            var item = ps.GetCurrentItem();

            if(item == null)
            {
                Logger.Instance.Log("Current Hand is empty!");
                return;
            }

            var innerItem = item.TryRemove();

            if(innerItem == null)
            {
                Logger.Instance.Log("Nothing hangs on the current item!");
                return;
            }

            if (!ps.TryAdd(innerItem))
            {
                if (DropItemValidator.IsValid(board, player.Pos))
                {
                     board.SetAt(player.Pos, innerItem);
                }
                else
                {
                    Logger.Instance.Log("No place to put the retrieved item!");
                    innerItem.AcceptItemVisitor(new CanBeHungVisitor(item));
                }
            }

            base.Execute(inpuEvent);
        }
    }
}
