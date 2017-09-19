namespace ClassDemoHTTPServer
{
    internal class PerformRequest
    {
        private HttpRequest req;

        public PerformRequest(HttpRequest req)
        {
            this.req = req;
        }

        public HttpResponse ProcessRequest()
        {
            
            return new HttpResponse();
        }
    }
}