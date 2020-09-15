using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Pagination;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class ConversationsHistoryResponse : SlackResponseBase
    {
        [JsonProperty("latest")]
        public string Latest { get; set; }
        
        [JsonProperty("messages")]
        public MessageResponse[] Messages { get; set; }
        
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("pin_count")]
        public long PinCount { get; set; }

        [JsonProperty("response_metadata")]
        public CursorPaginationMetadata Metadata { get; set; }

        [JsonProperty("channel_actions_ts")]
        public string ChannelActionsTimeStamp { get; set; } //TODO непонятно это должно быть стрингом или лонгом

        [JsonProperty("channel_actions_count")]
        public long? ChannelActionsCount { get; set; }
    }
}