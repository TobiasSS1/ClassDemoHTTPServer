using System;
using System.Collections.Generic;

namespace ClassDemoHTTPServer
{
    public class HttpRequest
    {
        private string _method;
        private string _uri;
        private string _version;

        private Dictionary<string, string> _headerFields;

        // body

        public string Method
        {
            get => _method;
            set
            {
                if (value.ToLower() != "get")
                {
                    //error
                    throw new HttpException("Bad request (method)", 400);
                }
                _method = value;
            }
        }

        public string Uri
        {
            get => _uri;
            set => _uri = value;
        }

        public string Version
        {
            get => _version;
            set
            {
                if (!(value.ToLower() == "http/1.0" || value.ToLower() == "http/1.1"))
                {
                    //error
                    throw new HttpException("Bad request (version)", 400);
                }
                _version = value;
            }
        }

        public Dictionary<string, string> HeaderFields
        {
            get => _headerFields;
            set => _headerFields = value;
        }

        public void AddHeader(string headerline)
        {
            string[] header = headerline.Split(':');
            if (header.Length != 2)
            {
                //error
            }

            _headerFields.Add(header[0], header[1].Trim());
        }

        public HttpRequest()
        {
            _headerFields = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            string str = String.Join(", ", _headerFields);
                return $"Method: {_method}, Uri: {_uri}, Version: {_version}, Headers={str}";
        }
    }
}