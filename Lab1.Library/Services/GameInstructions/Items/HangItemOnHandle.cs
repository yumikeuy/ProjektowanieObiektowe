using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Inventory;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Validators.ItemsValidators;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Services.GameInstructions.Items
{
    public class HangItemOnHandle : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['U'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.U];
        public override string Description { get; set; } = "Press \"U\" to hang an item to handler/weapon";
        public override void Execute(IInputEvent inpuEvent)
        {
            var ps = inpuEvent.Player.State;

            (var left, var right) = ps.GetItemsFromHands();

            Hands hand = ps.GetCurrentHand();

            var itemToHandOn = ps.GetCurrentItem();
            var itemToHandOnTo = hand switch
            {
                Hands.Left => right,
                Hands.Right => left, 
                _ => null!
            };

            if (itemToHandOn == null)
            {
                Logger.Instance.Log("No item in the current hand!");
            }
            else if (itemToHandOnTo == null)
            {
                Logger.Instance.Log("No item to hand on in the other hand!");
            }
            else
            {
                if (itemToHandOn.AcceptItemVisitor(new CanBeHungVisitor(itemToHandOnTo)))
                {
                    ps.TryRemoveAt(hand);
                }
                else
                {
                    Logger.Instance.Log("Can't hang this item!");
                }
            }

            base.Execute(inpuEvent);
        }
    }
}
