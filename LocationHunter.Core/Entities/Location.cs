namespace LocationHunter.Core.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public string Ip { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
