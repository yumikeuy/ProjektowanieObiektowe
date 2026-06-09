using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Connections
{
    public interface IConnectedClient : IDisposable
    {
        TcpClient TcpClient { get; }
        Task SendAsync(string message);
        Task<string> ReceiveAsync();
    }
}
