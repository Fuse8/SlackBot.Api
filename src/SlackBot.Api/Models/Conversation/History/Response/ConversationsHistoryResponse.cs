﻿using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Message;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class ConversationsHistoryResponse : CursorPaginationResponseBase
    {
        [JsonProperty("latest")]
        public string Latest { get; set; }
        
        [JsonProperty("messages")]
        public MessageResponse[] Messages { get; set; }
        
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("pin_count")]
        public long PinCount { get; set; }

        [JsonProperty("channel_actions_ts")]
        public string ChannelActionsTimestamp { get; set; } // TODO Couldn't find a description of this field in the documentation

        [JsonProperty("channel_actions_count")]
        public long? ChannelActionsCount { get; set; }
    }
}