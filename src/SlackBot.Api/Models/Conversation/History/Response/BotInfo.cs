using Newtonsoft.Json;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class BotInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("icons")]
        public BotIconItem Icons { get; set; }
    }
}