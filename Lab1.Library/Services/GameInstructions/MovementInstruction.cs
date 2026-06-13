using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Validators.MovementVaidators;

namespace Lab1.Library.Services.GameInstructions
{
    public class MovementInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['W', 'A', 'S', 'D'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D];
        public override string Description { get; set; } = "Press \"W\", \"A\", \"S\", \"D\" to move";
        public override void Execute(IInputEvent inputEvent)
        {
            var board = inputEvent.Game.GameState.Board;
            var player = inputEvent.Player;
            var pos = player.Pos;

            (Point newPos, char orientation) = inputEvent.Key switch
            {
                ConsoleKey.W => (pos.Up, 'U'),
                ConsoleKey.A => (pos.Left, 'L'),
                ConsoleKey.S => (pos.Down, 'D'),
                ConsoleKey.D => (pos.Right, 'R'),
                _ => (new(-1, -1), 'N')
            };

            if (MovementValidator.IsValid(board, newPos))
            {
                player.Pos = newPos;
                player.State.Orientation = orientation;
            }
            else
            {
                Logger.Instance.Log("Tried to go through the wall.");
            }

            base.Execute(inputEvent);
        }

    }
}
