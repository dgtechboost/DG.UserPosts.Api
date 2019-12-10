using Newtonsoft.Json;

namespace DG.UserPosts.Contracts
{
    public class AddressContract
    {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("suite")]
        public string Suite { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("geo")]
        public GeoContract Geo { get; set; }
    }
}
