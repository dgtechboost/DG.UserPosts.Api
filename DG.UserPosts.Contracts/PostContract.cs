using Newtonsoft.Json;

namespace DG.UserPosts.Contracts
{
    public class PostContract
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}