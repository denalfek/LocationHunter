using Newtonsoft.Json;

namespace LocationHunter.WebApi.IpStackModels
{
    public class IpStackResponseModel
    {
        [JsonProperty(PropertyName ="ip")]
        public string Ip { get; set; }

        [JsonProperty(PropertyName = "country_name")]
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "region_code")]
        public string RegionCode { get; set; }

        [JsonProperty(PropertyName = "region_name")]
        public string RegionName { get; set; }

        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public IpStackLocationResponseModel Location { get; set; }
    }
}
