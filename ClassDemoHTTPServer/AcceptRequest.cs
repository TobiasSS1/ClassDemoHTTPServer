using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace ClassDemoHTTPServer
{
    internal class AcceptRequest
    {
        private TcpClient client;

        public AcceptRequest(TcpClient client)
        {
            this.client = client;
        }

        public HttpRequest ReadRequest()
        {
            HttpRequest req = new HttpRequest();

            using (StreamReader sr = new StreamReader(client.GetStream()))
            {
                String reqLine = sr.ReadLine();
                Trace.TraceInformation("New request line " + reqLine);

                String[] reqs = reqLine.Split(' ');
                if (reqs.Length != 3)
                {
                    //error
                    throw new HttpException("Bad request", 400);
                }

                req.Method = reqs[0];
                req.Uri = reqs[1];
                req.Version = reqs[2];

                String hline = sr.ReadLine();
                while (String.IsNullOrEmpty(hline))
                {
                    req.AddHeader(hline);

                    hline = sr.ReadLine();
                }


                // read body
            }


            return req;
        }
    }
}