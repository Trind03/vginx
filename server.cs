using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
# nullable enable

namespace server
{
    internal class Server
    {
        public string fetchType(string filename)
        {
            switch(Path.GetExtension(filename))
            {
                case ".html":
                    return "text/html";
                case ".css":
                    return "text/css";
                case ".js":
                    return "application/javascript";
                case ".png":
                    return "image/png";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }
        public int start_server()
        {
            while(running_status)
            {
                Context = Listener.GetContext();
                Request = Context.Request;
                Response = Context.Response;
                Response.ContentLength64 = Buffer.Length;
                
                string RequestedFile = Request!.Url.LocalPath.Trim('/');
                if(string.IsNullOrEmpty(RequestedFile))
                {
                    RequestedFile = "index.html";
                }

                if(File.Exists(RequestedFile))
                {
                    Buffer = File.ReadAllBytes(RequestedFile);
                    Response.ContentLength64 = Buffer.Length;
                    Response.ContentType = fetchType(RequestedFile);
                    Response.OutputStream.Write(Buffer,0,Buffer.Length);
                }

                else
                {
                    Buffer = System.Text.Encoding.UTF8.GetBytes("<h1>Error data source not found :< </h1>");
                }

                
                System.IO.Stream Output = Response.OutputStream;
                Output.Write(Buffer,0,Buffer.Length);
            }
            return 0;
        }
        public Server(int port)
        {
            try
            {
                Listener = new HttpListener();
                Listener!.Prefixes.Add($"http://*:{port}/");
                Listener!.Start();
            }

            catch(System.Exception)
            {
                System.Console.Write("Error failed to start up.");
            }
        }

        private byte[] Buffer = {};
        private HttpListener Listener;
        private NetworkStream? Stream;
        private HttpListenerContext? Context;
        private HttpListenerRequest? Request;
        private HttpListenerResponse? Response;
        private bool running_status = true;
    }
}