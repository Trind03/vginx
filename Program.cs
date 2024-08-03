using System.Net;
using System.IO;
using System.Threading;
using server;


namespace program
{
    internal class Program
    {
        public static int Main()
        {
            Server server = new Server(8080);
            server.start_server();
            return 0;
        }
    }
}