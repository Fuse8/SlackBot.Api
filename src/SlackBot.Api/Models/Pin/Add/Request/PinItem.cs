using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.Pin.Add.Request
{
	public class PinItem
	{
		public PinItem()
		{
		}

		public PinItem(string channelId, string messageTimestamp)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
		}

		/// <summary>
		/// Channel to pin the item in.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Timestamp of the message to pin.
		/// </summary>
		/// <example>1234567890.123456</example>
		[FormPropertyName("timestamp")]
		public string MessageTimestamp { get; set; }
	}
}