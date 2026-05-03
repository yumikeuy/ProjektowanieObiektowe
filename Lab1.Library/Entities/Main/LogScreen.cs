using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Entities.Main
{
    public class LogScreen : ILogScreen
    {
        public bool FullScreen { get; set; } = false;
        public Point PrintAt { get; set; }

        private Point printAtFullScreen = (1, 1);

        private int lastLogsCount = 3;

        public IPrintable Text()
        {
            Printable logsPrintable = new();

            var logs = Logger.Instance.GetLogs();

            if (FullScreen)
            {
                int i = 0;
                foreach (var line in logs)
                {
                    logsPrintable.AddText(new TextPos(line, printAtFullScreen.DownN(i++)));
                }
            }
            else
            {
                for (int i = 0; i < lastLogsCount; i++)
                {
                    if (i < logs.Length)
                        logsPrintable.AddText(new TextPos(logs[logs.Length - i - 1].Trim(), PrintAt.DownN(i)));
                }
            }

            return logsPrintable;
        }

        public LogScreen(int boardHeight)
        {
            PrintAt = (1, boardHeight + 4);
        }
    }
}
