using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Events;

namespace Lab1.Library.Services.EventsMediators.Noise
{
    public class NoiseData(Point src, int radius, IBoard board, string description) : INoiseData
    {
        public Point Source { get; } = src;
        public string Description { get; } = description;
        public bool CanHear(Point pos, out int dist)
        {
            return board.IsReachable(Source, pos, radius, out dist);
        }
    }
}
