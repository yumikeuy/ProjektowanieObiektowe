using System;
using System.Collections.Generic;
using Lab1.Library.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Events
{
    public interface INoiseData : IEventData
    {
        public bool CanHear(Point pos, out int dist);
        public Point Source { get; }
        public string Description { get; }
    }
}
