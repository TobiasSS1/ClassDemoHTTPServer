namespace ClassDemoHTTPServer
{
    public class HttpResponse
    {
        private string _version;
        private string _text;
        private int _code;

        // header +body

        public string Version
        {
            get => _version;
            set => _version = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public int Code
        {
            get => _code;
            set => _code = value;
        }
    }
}