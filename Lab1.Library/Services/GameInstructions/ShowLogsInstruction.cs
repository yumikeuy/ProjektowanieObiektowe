using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Logging;

namespace Lab1.Library.Services.GameInstructions
{
    public class ShowLogsInstruction : ActionInstruction
    {
        public override ICollection<char> Chars { get; set; } = ['J'];
        public override ICollection<ConsoleKey> Keys { get; set; } = [ConsoleKey.J];
        public override string Description { get; set; } = "Press \"J\" to show the log screen";
        public override void Execute(IInputEvent inputEvent)
        {
            inputEvent.Game.Printer.PrepareConsole();
            inputEvent.Game.Printer.PrintText(string.Join(Environment.NewLine, Logger.Instance.GetLogs()));
            Console.ReadKey();
            inputEvent.Game.Printer.PrepareConsole();
            base.Execute(inputEvent);
        }
    }
}
