using System.Net;
using System.IO;
using server;


namespace program
{
    internal class Program
    {
        public static int Main()
        {
            Server server = new Server(8080);

            if(File.Exists("./index.html"))
            {
                string? Data = File.ReadAllLines("./index.html").ToString();
                if(Data == null)
                {
                    server.Buffer = System.Text.Encoding.UTF8.GetBytes("<h1>Server error, null referance :< </h1>");
                    return -1;
                }
                server.Buffer = System.Text.Encoding.UTF8.GetBytes(Data);
            }
            else
            {
                string? Data = "<h1>Error data source not found :< </h1>";
                server.Buffer = System.Text.Encoding.UTF8.GetBytes(Data);
            }
            server.Context = server.Listener.GetContext();
            server.Request = server.Context.Request;
            server.Response = server.Context.Response;

            server.Response.ContentLength64 = server.Buffer.Length;
            System.IO.Stream Output = server.Response.OutputStream;
            Output.Write(server.Buffer,0,server.Buffer.Length);
            return 0;
        }
    }
}