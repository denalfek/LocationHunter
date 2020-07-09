using System;

namespace LocationHunter.Core.Configurations
{
    public class HttpClientConfig
    {
        public Uri Uri { get; set; }
        public string AccessKey { get; set; }
        public string ClientName { get; set; }
    }
}
