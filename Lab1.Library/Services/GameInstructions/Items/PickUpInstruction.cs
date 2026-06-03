using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.EventsMediators.Noise;
using Lab1.Library.Services.GameInstructions;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Validators.ItemsValidators;
using Lab1.Library.Services.Visitors;
using Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors;

namespace Lab1.Library.Services.GameInstructions.Items
{
    public class PickUpInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['E'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.E];
        public override string Description { get; set; } = "Press \"E\" to pick up the item";
        public override void Execute(IInputEvent inputEvent)
        {
            var player = inputEvent.Player;
            var board = inputEvent.Game.GameState.Board;

            if (PickUpItemValidator.IsValid(board, player.Pos, player.State))
            {
                Logger.Instance.Log("Picked up an item.");

                var noiseVisitor = new NoiseWeaponVisitor();
                ((IItem)board.GetAt(player.Pos)).AcceptItemVisitor(noiseVisitor);

                board.SetAt(player.Pos, new EmptyGameObject());

                var noiseData = new NoiseData(player.Pos, noiseVisitor.Radius, board, "Picking up an item");
                inputEvent.Game.GameState.MediatorsDirector.NoiseMediator.Notify(noiseData);
            }                
                

            base.Execute(inputEvent);
        }

    }
}
