using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoHTTPServer
{
    public class HttpException:Exception
    {
        private int _code;

        public int Code => _code;

        public HttpException(string statusmessage, int statusCode) : base(statusmessage)
        {
            _code = statusCode;
        }
    }
}
