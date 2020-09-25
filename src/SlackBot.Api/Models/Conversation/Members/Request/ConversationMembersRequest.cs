using SlackBot.Api.Attributes;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Conversation.Members.Request
{
	public class ConversationMembersRequest : CursorPaginationBase
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