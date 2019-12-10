using Newtonsoft.Json;

namespace DG.UserPosts.Contracts
{
    public class CompanyContract
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty("bs")]
        public string Bs { get; set; }
    }
}
