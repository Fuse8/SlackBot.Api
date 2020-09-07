using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class PinnedInfo
    {
        [JsonPropertyName("channel")]
        public string ChannelId { get; set; }

        [JsonPropertyName("pinned_by")]
        public string PinnedById { get; set; }

        [JsonPropertyName("pinned_ts")]
        public long PinnedOn { get; set; }
    }
}