using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationHunter.WebApi
{
    public class ResponseModel
    {
        public string Ip { get; set; }
        public string HostName { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public LocationResponse Location { get; set; }
    }

    public class LocationResponse
    {
        public string Capital { get; set; }
    }
}
