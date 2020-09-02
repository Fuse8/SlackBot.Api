using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels
{
    public class Message
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}