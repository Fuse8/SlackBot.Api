using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class MessageReactionItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("count")]
        public long Count { get; set; }
        
        [JsonPropertyName("users")]
        public List<string> UserIds { get; set; }
    }
}