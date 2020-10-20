using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class SlackReaction
	{
		public SlackReaction()
		{
		}

		public SlackReaction(string channelId, string messageTimestamp, string emojiName)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
			EmojiName = emojiName;
		}

		/// <summary>
		/// Channel where the message to add reaction to was posted.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Reaction (emoji) name.
		/// </summary>
		/// <example>grinning</example>
		[FormPropertyName("name")]
		public string EmojiName { get; set; }

		/// <summary>
		/// Timestamp of the message to add reaction to.
		/// </summary>
		/// <example>1234567890.123456</example>
		[FormPropertyName("timestamp")]
		public string MessageTimestamp { get; set; }
	}
}