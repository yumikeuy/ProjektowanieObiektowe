using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.GameInstructions;
using Lab1.Library.Services.Validators.ItemsValidators;

namespace Lab1.Library.Services.GameInstructions.Items
{
    public class DropItemInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['Q'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.Q];
        public override string Description { get; set; } = "Press \"Q\" to drop item from current hand";
        public override void Execute(IInputEvent inpuEvent)
        {
            var board = inpuEvent.GameState.Board;
            var player = inpuEvent.GameState.Player;

            if (DropItemValidator.IsValid(board, player.Pos))
            {
                var item = player.State.Drop();
                if (item != null)
                    board.SetAt(player.Pos, item);
            }

            base.Execute(inpuEvent);
        }
    }
}
