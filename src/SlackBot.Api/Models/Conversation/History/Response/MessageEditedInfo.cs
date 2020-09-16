using Newtonsoft.Json;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class MessageEditedInfo
    {
        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }
    }
}