using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ClassDemoHTTPServer
{
    public class HTTPServer
    {
        private readonly int _port;

        public HTTPServer(int port)
        {
            this._port = port;
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Any, _port);
            server.Start();
            Trace.TraceInformation("Server started on " + _port);

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Trace.TraceInformation("New Client");
                Task.Run(() =>
                    {
                        TcpClient socket = client;
                        DoClient(client);
                    }
                );
            }
        }

        private void DoClient(TcpClient client)
        {
            // do something

            Trace.Flush();
        }
    }
}