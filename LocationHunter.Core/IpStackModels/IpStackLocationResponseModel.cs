using Newtonsoft.Json;

namespace LocationHunter.Core.IpStackModels
{
    public class IpStackLocationResponseModel
    {
        public string Capital { get; set; }

        [JsonProperty(PropertyName = "country_flag")]
        public string CountryFlagPictureUrl { get; set; }
    }
}
