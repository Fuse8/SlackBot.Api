using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
    public class ConversationsHistoryResponse : CursorPaginationResponseBase
    {
        [JsonProperty("latest")]
        public string Latest { get; set; }
        
        [JsonProperty("messages")]
        public List<MessageObject> Messages { get; set; }
        
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("pin_count")]
        public long PinCount { get; set; }

        [JsonProperty("channel_actions_ts")]
        public string ChannelActionsTimestamp { get; set; }// TODO Couldn't find a description of this field in the documentation

        [JsonProperty("channel_actions_count")]
        public long? ChannelActionsCount { get; set; }
    }
}