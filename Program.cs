using System.Net;
using System.IO;
using System.Threading;
using app.server;

namespace program
{
    internal class Program
    {
        public static int Main()
        {
            Command _Command = new Command(0,0);
            Thread _Command_h = new Thread(_Command.command_handler);
            Server server = new Server(8080);
            server.start_server();
            return 0;
        }
    }
}