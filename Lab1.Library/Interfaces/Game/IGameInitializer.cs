using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;
using Lab1.Library.Interfaces.GameBuilders.BuildingThemes;

namespace Lab1.Library.Interfaces.Game
{
    public interface IGameInitializer
    {
        void Initialize(bool isServer, IPEndPoint iPEndPoint);
    }
}
