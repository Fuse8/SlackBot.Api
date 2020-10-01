using SlackBot.Api.Attributes;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.List.Request
{
	public class ConversationListRequest : CursorPaginationBase
	{
		public ConversationListRequest()
		{
		}

		public ConversationListRequest(string types, string cursor = null, long? limit = null)
			: base(cursor, limit)
		{
			Types = types;
		}

		/// <summary>
		/// Set to "true" to exclude archived channels from the list.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("exclude_archived")]
		public bool? ExcludeArchived { get; set; }

		/// <summary>
		/// Mix and match channel types by providing a comma-separated list of any combination of "public_channel", "private_channel", "mpim", "im".
		/// <para><strong>Default: public_channel</strong></para>
		/// </summary>
		/// <example>public_channel,private_channel</example>
		[FormPropertyName("types")]
		public string Types { get; set; }
	}
}