using System.Net;
using System.IO;


namespace program
{
    internal class Program
    {
        public static byte[] Response = {};
        public static void Main()
        {
            HttpListener Server = new HttpListener();
            Server.Prefixes.Add("0.0.0.0::8080");

            // ** Open for refactoring - Possible null referance from this expression **
            if(File.Exists("./index.html"))
            {
                string? Data = File.ReadAllLines("./index.html").ToString();
                Response = System.Text.Encoding.UTF8.GetBytes(Data);
            }
            else
            {
                string? Data = "<h1>Error data source not found :< </h1>";
                Response = System.Text.Encoding.UTF8.GetBytes(Data);
            }

        }
    }
}