using System;
using System.Collections.Generic;
using System.Net;

namespace LocationHunter.Core.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public IPAddress Ip { get; set; }

        public string Name { get; set; }
    }
}
