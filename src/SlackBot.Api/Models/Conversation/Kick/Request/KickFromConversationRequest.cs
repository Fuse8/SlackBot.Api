using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.Conversation.Kick.Request
{
	public class KickFromConversationRequest : ConversationRequestBase
	{
		public KickFromConversationRequest()
		{
		}

		public KickFromConversationRequest(string channelId, string userId)
			: base(channelId)
		{
			UserId = userId;
		}

		/// <summary>
		/// User ID to be removed.
		/// </summary>
		/// <example>W1234567890</example>
		[FormPropertyName("user")]
		public string UserId { get; set; }
	}
}