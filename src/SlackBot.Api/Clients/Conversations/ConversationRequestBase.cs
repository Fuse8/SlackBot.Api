using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public abstract class ConversationRequestBase
	{
		protected ConversationRequestBase()
		{
		}

		protected ConversationRequestBase(string channelId)
		{
			ChannelId = channelId;
		}

		/// <summary>
		/// ID of conversation
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }
	}
}