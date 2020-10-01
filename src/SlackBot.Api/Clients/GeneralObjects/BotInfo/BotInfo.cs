using Newtonsoft.Json;

namespace SlackBot.Api.Clients.GeneralObjects.BotInfo
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
        public BotIcons Icons { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }
    }
}