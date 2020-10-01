using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class UserConversations : CursorPaginationWithTimestampBase
	{
		public UserConversations()
		{
		}

		public UserConversations(string types, string userId = null)
		{
			Types = types;
			UserId = userId;
		}

		/// <summary>
		/// Set to "true" to exclude archived channels from the list
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("exclude_archived")]
		public bool? ExcludeArchived { get; set; }
		
		/// <summary>
		/// Mix and match channel types by providing a comma-separated list of any combination of "public_channel", "private_channel", "mpim", "im"
		/// <para><strong>Default: public_channel</strong></para>
		/// </summary>
		/// <example>im,mpim</example>
		[FormPropertyName("types")]
		public string Types { get; set; }

		/// <summary>
		/// Browse conversations by a specific user ID's membership. Non-public channels are restricted to those where the calling user shares membership.
		/// </summary>
		/// <example>W0B2345D</example>
		[FormPropertyName("user")]
		public string UserId { get; set; }
	}
}