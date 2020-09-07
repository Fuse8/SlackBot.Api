using System.Text.Json.Serialization;
using SlackBot.Api.Models.GeneralObjects.Pagination;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class ConversationsHistoryResponse : SlackResponseBase
    {
        [JsonPropertyName("latest")]
        public string Latest { get; set; }
        
        [JsonPropertyName("messages")]
        public MessageResponse[] Messages { get; set; }
        
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        [JsonPropertyName("pin_count")]
        public long PinCount { get; set; }

        [JsonPropertyName("response_metadata")]
        public CursorPaginationMetadata Metadata { get; set; }

        [JsonPropertyName("channel_actions_ts")]
        public string ChannelActionsTimeStamp { get; set; } //TODO непонятно это должно быть стрингом или лонгом

        [JsonPropertyName("channel_actions_count")]
        public long? ChannelActionsCount { get; set; }
    }
}