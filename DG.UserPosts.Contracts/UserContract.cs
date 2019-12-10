using Newtonsoft.Json;

namespace DG.UserPosts.Contracts
{
    public class UserContract
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("address")]
        public AddressContract Address { get; set; }
        [JsonProperty("company")]
        public CompanyContract Company { get; set; }
    }
}