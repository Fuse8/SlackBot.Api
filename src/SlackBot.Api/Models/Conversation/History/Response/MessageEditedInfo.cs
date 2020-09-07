using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class MessageEditedInfo
    {
        [JsonPropertyName("user")]
        public string UserId { get; set; }

        [JsonPropertyName("ts")]
        public string EditedOn { get; set; }
    }
}