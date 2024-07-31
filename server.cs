using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;

namespace server
{
    internal class Server
    {
        public Server(int port)
        {
            try
            {
                Listener = new HttpListener();
                Listener.Prefixes.Add($"http://*:{port}/");
                
            }

            catch(System.Exception)
            {
                System.Console.Write("Error failed to start up.");
            }
            Listener.Start();
            Buffer = null;
        }

        public byte[]? Buffer;
        public HttpListener? Listener;
        public NetworkStream? Stream;
        public HttpListenerContext? Context;
        public HttpListenerRequest? Request;
        public HttpListenerResponse? Response;
    }
}