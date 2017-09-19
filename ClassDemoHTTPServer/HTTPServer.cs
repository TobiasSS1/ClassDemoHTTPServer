using System;
using System.Diagnostics;
using System.IO;
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

            HttpResponse resp = new HttpResponse();
            try
            {
                AcceptRequest accept = new AcceptRequest(client);
                HttpRequest req = accept.ReadRequest();
                Trace.TraceInformation(req.ToString());
                Trace.Flush();

                PerformRequest perform = new PerformRequest(req);
                resp = perform.ProcessRequest();
            }
            catch (HttpException he)
            {
                resp.Code = he.Code;
                resp.Text = he.Message;
            }
            

            SendResponse sendResp = new SendResponse(client, resp);
            sendResp.Send();




            Trace.Flush();
        }
    }

    
}