using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class ConversationToInvite : ConversationRequestBase
	{
		public ConversationToInvite()
		{
		}

		public ConversationToInvite(string channelId, string userIds)
			: base(channelId)
		{
			UserIds = userIds;
		}

		/// <summary>
		/// A comma separated list of user IDs. Up to 1000 users may be listed.
		/// </summary>
		/// <example>W1234567890,U2345678901,U3456789012</example>
		[FormPropertyName("users")]
		public string UserIds { get; set; }
	}
}