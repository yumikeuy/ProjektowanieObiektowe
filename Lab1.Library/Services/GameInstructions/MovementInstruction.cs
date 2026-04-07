using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Extensions.PointExtensions;
using Lab1.Library.Interfaces.Game;
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
            var board = inputEvent.GameState.Board;
            var player = inputEvent.GameState.Player;
            var pos = player.Pos;

            Point newPos = inputEvent.Key switch
            {
                ConsoleKey.W => pos.Up(),
                ConsoleKey.A => pos.Left(),
                ConsoleKey.S => pos.Down(),
                ConsoleKey.D => pos.Right(),
                _ => new(-1, -1)
            };

            if (MovementValidator.IsValid(board, newPos))
                player.Pos = newPos;

            base.Execute(inputEvent);
        }

    }
}
