using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.Events
{
    public interface IKillData : IEventData
    {
        Point Pos { get; set; }
    }
}
