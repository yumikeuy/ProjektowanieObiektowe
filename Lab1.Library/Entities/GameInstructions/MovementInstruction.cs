using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameInstructions
{
    public class MovementInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['W', 'A', 'S', 'D'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D];
        public override string Description { get; set; } = "Press \"W\", \"A\", \"S\", \"D\" to move";
        public override void Execute(IInputEvent inputEvent)
        {
            var gs = inputEvent.GameState;
            switch (inputEvent.Key)
            {
                case ConsoleKey.W:
                    gs.Board.TryMovePlayer(gs.Player, new(gs.Player.Pos.X, gs.Player.Pos.Y - 1));
                    break;
                case ConsoleKey.A:
                    gs.Board.TryMovePlayer(gs.Player, new(gs.Player.Pos.X - 1, gs.Player.Pos.Y));
                    break;
                case ConsoleKey.S:
                    gs.Board.TryMovePlayer(gs.Player, new(gs.Player.Pos.X, gs.Player.Pos.Y + 1));
                    break;
                case ConsoleKey.D:
                    gs.Board.TryMovePlayer(gs.Player, new(gs.Player.Pos.X + 1, gs.Player.Pos.Y));
                    break;
            }

            base.Execute(inputEvent);
        }

    }
}
