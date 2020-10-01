using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class ConversationToRename : ConversationRequestBase
	{
		public ConversationToRename()
		{
		}

		public ConversationToRename(string channelId, string name)
			: base(channelId)
		{
			Name = name;
		}

		/// <summary>
		/// New name for conversation.
		/// </summary>
		/// <example>new-channel-name</example>
		[FormPropertyName("name")]
		public string Name { get; set; }
	}
}