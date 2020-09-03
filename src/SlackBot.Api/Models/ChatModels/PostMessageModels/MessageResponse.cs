using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels
{
    public class MessageResponse : SlackResponseBase
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")]
        public string ThreadId { get; set; }
    }
}