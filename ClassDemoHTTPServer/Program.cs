using System;
using System.Diagnostics;
using System.IO;

namespace ClassDemoHTTPServer
{
    class Program
    {
        private const int port = 8080;
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener(new StreamWriter(@"m:\intpub\httpServer.log")));

            HTTPServer server = new HTTPServer(port);
            server.Start();

            Console.ReadLine();
        }
    }
}
