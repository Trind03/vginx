using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;

namespace server
{
    internal class Server
    {
        public string fetch_type(string filename)
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
                if(File.Exists("./index.html"))
                {
                    string? Data = "";
                    foreach(string c in File.ReadAllLines("./index.html"))  Data = Data + c;
                    if(Data == null)
                    {
                        Buffer = System.Text.Encoding.UTF8.GetBytes("<h1>Server error, null referance :< </h1>");
                        return 1;
                    }
                    Buffer = System.Text.Encoding.UTF8.GetBytes(Data);
                }
                else
                {
                    string? Data = "<h1>Error data source not found :< </h1>";
                    Buffer = System.Text.Encoding.UTF8.GetBytes(Data);
                }

                Context = Listener.GetContext();
                Request = Context.Request;
                string Requested_file = Request.Url.LocalPath.Trim('/');
                Response = Context.Response;
                System.Console.Write(Requested_file,"Hello world");
                Response.ContentLength64 = Buffer.Length;
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
                Listener.Prefixes.Add($"http://*:{port}/");
                Listener.Start();
            }

            catch(System.Exception)
            {
                System.Console.Write("Error failed to start up.");
            }
        }

        public byte[] Buffer = {};
        public HttpListener Listener;
        public NetworkStream? Stream;
        public HttpListenerContext? Context;
        public HttpListenerRequest? Request;
        public HttpListenerResponse? Response;
        private bool running_status = true;
    }
}