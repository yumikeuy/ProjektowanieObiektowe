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
    public class PickUpInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['E'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.E];
        public override string Description { get; set; } = "Press \"E\" to pick up the item";
        public override void Execute(IInputEvent inputEvent)
        {
            var player = inputEvent.GameState.Player;
            var board = inputEvent.GameState.Board;

            if (PickUpItemValidator.IsValid(board, player.Pos))
            {
                board.GetAt(player.Pos).Pick(player.State);
                board.SetAt(player.Pos, new EmptyGameObject());
            }

            base.Execute(inputEvent);
        }

    }
}
