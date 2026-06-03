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

        public (bool, IPEndPoint, string) HandleArgs(string[] args)
        {
            if (args.Length < 2 || args.Length > 3)
            {
                Usage();
            }


            if (args[1] == "--server" || args[1] == "-s")
            {
                if (args.Length > 2 && int.TryParse(args[2], out var port) && 0 <= port && port <= 65535)
                {
                    return (true, new(defaultIp, port), args[0]);
                }
                else
                {
                    return (true, new(defaultIp, defaultPort), args[0]);
                }
            }
            else if(args[1] == "--client" || args[1] == "-c")
            {
                if (args.Length > 2 && IPEndPoint.TryParse(args[2], out var ipEndPoint))
                {
                    return (false, ipEndPoint, args[0]);
                }
                else
                {
                    return (false, new(defaultIp, defaultPort), args[0]);
                }
            }

            Usage();
            return (false, new(0, 0), ""); // Not reachable
        }

        private void Usage()
        {
            System.Console.WriteLine("Usage: program nickname --server (or -s) [port]\n\t program nickname --client (or -c) [port]\n default adress: 127.0.0.1:5555\n");
            System.Console.ReadKey();
            Environment.Exit(1);
        }

    }
}
