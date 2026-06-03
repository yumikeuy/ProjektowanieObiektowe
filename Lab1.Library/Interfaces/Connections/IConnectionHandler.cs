using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.Connections
{
    public interface IConnectionHandler
    {
        Task<IGame> ConnectAsync(IPEndPoint ipep, string name);
        void SendCommandToServerAsync(ConsoleKey key);
        void Disconnect();
    }
}
