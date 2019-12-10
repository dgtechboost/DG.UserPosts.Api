using Newtonsoft.Json;

namespace DG.UserPosts.Contracts
{
    public class GeoContract
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }
    }
}
