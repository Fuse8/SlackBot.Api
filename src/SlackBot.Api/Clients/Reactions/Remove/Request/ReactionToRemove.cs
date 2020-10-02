using SlackBot.Api.Attributes;

namespace SlackBot.Api
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