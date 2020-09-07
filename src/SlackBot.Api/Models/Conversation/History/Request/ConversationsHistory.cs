using SlackBot.Api.Attributes;
using SlackBot.Api.Models.GeneralObjects.Pagination;

namespace SlackBot.Api.Models.Conversation.History.Request
{
    public class ConversationsHistory : CursorPaginationBase
    {
        [FormPropertyName("channel")]
        public string ChannelId { get; set; }

        [FormPropertyName("inclusive")]
        public bool? Inclusive { get; set; }

        [FormPropertyName("latest")]
        public string Latest { get; set; }

        [FormPropertyName("limit")]
        public long? Limit { get; set; }
		
        [FormPropertyName("oldest")]
        public string Oldest { get; set; }
    }
}