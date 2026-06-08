using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Connections;

namespace Lab1.Library.Services.Connections
{
    public class ConnectedClient : IConnectedClient
    {
        private readonly object _writeLock = new(); 
        private readonly StreamWriter _writer;
        private readonly StreamReader _reader;

        public TcpClient TcpClient { get; }

        public ConnectedClient(TcpClient client)
        {
            TcpClient = client;
            var stream = client.GetStream();
            _writer = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true };
            _reader = new StreamReader(stream, Encoding.UTF8);
        }

        public ConnectedClient(IPEndPoint ipep)
        {
            TcpClient = new TcpClient();
            TcpClient.ConnectAsync(ipep.Address, ipep.Port).Wait();
            var stream = TcpClient.GetStream();
            _writer = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true };
            _reader = new StreamReader(stream, Encoding.UTF8);
        }

        public void Send(string message)
        {
            Task.Run(() => {
                lock (_writeLock)
                {
                    _writer.WriteLine(message);
                }
            });
        }

        public async Task<string> ReceiveAsync()
        { 
            var message = await _reader.ReadLineAsync();

            if (message == null)
            {
                return string.Empty;
            }

            return message;
        }

        public void Dispose() => TcpClient?.Dispose();
    }
}
