using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels
{
    public class MessageResponse : SlackResponseBase
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("ts")]
        public string ThreadId { get; set; }
    }
}