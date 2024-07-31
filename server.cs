using System.Net;
using System.IO;
using System.Text;

namespace server
{
    internal class Server
    {
        public Server(UInt16 port)
        {
            try
            {
                Listener = new HttpListener();
                Listener.Prefixes.Add($"http://0.0.0.0::{port}/");
            }

            catch(System.Exception)
            {
                System.Console.Write("Error failed to start up.");
            }
            Response = null;
        }



        byte[]? Response;
        HttpListener? Listener;
    }
}