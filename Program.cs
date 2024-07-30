using System.Net;
using System.IO;


namespace program
{
    internal class Program
    {
        public static void Main()
        {
            HttpListener Server = new HttpListener();
            Server.Prefixes.Add("0.0.0.0::8080");

            // ** Open for refactoring - Possible null referance from this expression **
            byte[] Response = System.Text.Encoding.UTF8.GetBytes(File.ReadAllLines("./index.html").ToString());
        }
    }
}