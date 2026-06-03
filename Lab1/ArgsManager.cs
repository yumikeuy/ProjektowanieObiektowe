using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Console
{
    public class ArgsManager(IPEndPoint ipEndPoint)
    {
        private readonly IPAddress defaultIp = ipEndPoint.Address;
        private readonly int defaultPort = ipEndPoint.Port;

        public (bool, IPEndPoint) HandleArgs(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Usage();
            }

            if (args[0] == "--server" || args[0] == "-s")
            {
                if (args.Length > 1 && int.TryParse(args[1], out var port) && 0 <= port && port <= 65535)
                {
                    return (true, new(defaultIp, port));
                }
                else
                {
                    return (true, new(defaultIp, defaultPort));
                }
            }
            else if(args[0] == "--client" || args[0] == "-c")
            {
                if (args.Length > 1 && IPEndPoint.TryParse(args[1], out var ipEndPoint))
                {
                    return (false, ipEndPoint);
                }
                else
                {
                    return (false, new(defaultIp, defaultPort));
                }
            }

            Usage();
            return (false, new(0, 0)); // Not reachable
        }

        private void Usage()
        {
            System.Console.WriteLine("Usage: program --server (or -s) [port]\n\t program --client (or -c) [port]\n default adress: 127.0.0.1:5555\n");
            Environment.Exit(1);
        }

    }
}
