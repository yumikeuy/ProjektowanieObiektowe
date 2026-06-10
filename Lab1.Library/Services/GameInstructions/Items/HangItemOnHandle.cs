using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
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

            if (left == null || right == null) return;


            if (left.AcceptItemVisitor(new CanBeHungVisitor(right)))
            {
                ps.TryRemoveLeft();
            }
            else if (right.AcceptItemVisitor(new CanBeHungVisitor(left)))
            {
                ps.TryRemoveRight();
            }

            base.Execute(inpuEvent);
        }
    }
}
