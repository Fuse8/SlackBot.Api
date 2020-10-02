using Newtonsoft.Json;

namespace SlackBot.Api
{
    public class MessageObjectEditedInfo
    {
        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }
    }
}