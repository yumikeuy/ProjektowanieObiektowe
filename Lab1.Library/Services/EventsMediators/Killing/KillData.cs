using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Events;

namespace Lab1.Library.Services.EventsMediators.Killing
{
    public class KillData(Point pos) : IKillData
    {
        public Point Pos { get; set; } = pos;
    }
}
