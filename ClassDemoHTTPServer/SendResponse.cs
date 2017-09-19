using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoHTTPServer
{
    class SendResponse
    {
        private TcpClient client;
        private HttpResponse resp;

        public SendResponse(TcpClient client, HttpResponse resp)
        {
            this.client = client;
            this.resp = resp;
        }

        public void Send()
        {
            

        }
    }
}
