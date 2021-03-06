﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class ConversationMembersRequest : CursorPaginationRequestBase
	{
		public ConversationMembersRequest()
		{
		}

		public ConversationMembersRequest(string channelId, string cursor = null, long? limit = null)
			: base(cursor, limit)
		{
			ChannelId = channelId;
		}

		/// <summary>
		/// ID of the conversation to retrieve members for
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }
	}
}