using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
    public class MessageEditedInfo
    {
        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }
    }
}