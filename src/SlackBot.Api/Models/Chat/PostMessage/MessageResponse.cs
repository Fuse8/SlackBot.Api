using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage
{
    public class MessageResponse : SlackResponseBase
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")]
        public string ThreadId { get; set; }
    }
}