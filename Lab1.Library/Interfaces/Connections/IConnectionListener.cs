using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.Connections
{
    public interface IConnectionListener
    {
        void Start(IPEndPoint ipep, IGame game);
        Task SendChangesToPlayerAsync(IPlayer player);
        Task BroadcastChangesAsync(GameChanges changes);
    }
}
