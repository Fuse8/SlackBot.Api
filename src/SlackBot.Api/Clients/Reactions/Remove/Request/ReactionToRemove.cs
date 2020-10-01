using SlackBot.Api.Attributes;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Remove.Request
{
	public class ReactionToRemove : ItemActionRequestBase
	{
		public ReactionToRemove()
		{
		}

		public ReactionToRemove(string channelId, string messageTimestamp, string emojiName)
			: base(channelId, messageTimestamp)
		{
			EmojiName = emojiName;
		}

		/// <summary>
		/// Reaction (emoji) name.
		/// </summary>
		/// <example>grinning</example>
		[FormPropertyName("name")]
		public string EmojiName { get; set; }
	}
}