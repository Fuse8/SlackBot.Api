using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.Chat.GetPermalink.Request
{
	public class MessageToGetPermalink
	{
		public MessageToGetPermalink()
		{
		}

		public MessageToGetPermalink(string channelId, string messageTimestamp)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
		}

		/// <summary>
		/// The ID of the conversation or channel containing the message
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// A message's "ts" value, uniquely identifying it within a channel
		/// </summary>
		/// <example>1234567890.123456</example>
		[FormPropertyName("message_ts")]
		public string MessageTimestamp { get; set; }
	}
}