using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class ConversationPurposeRequest : ConversationRequestBase
	{
		public ConversationPurposeRequest()
		{
		}

		public ConversationPurposeRequest(string channelId, string purpose)
			: base(channelId)
		{
			Purpose = purpose;
		}

		/// <summary>
		/// A new, specialer purpose
		/// </summary>
		/// <example>My More Special Purpose</example>
		[FormPropertyName("purpose")]
		public string Purpose { get; set; }
	}
}