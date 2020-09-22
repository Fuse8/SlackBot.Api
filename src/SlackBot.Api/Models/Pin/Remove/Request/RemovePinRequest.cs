using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.Pin.Remove.Request
{
	public class RemovePinRequest
	{
		public RemovePinRequest()
		{
		}

		public RemovePinRequest(string channelId, string messageTimestamp)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
		}

		/// <summary>
		/// Channel where the item is pinned to.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// File to un-pin.
		/// </summary>
		/// <example>F1234567890</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }

		/// <summary>
		/// File comment to un-pin.
		/// </summary>
		/// <example>Fc1234567890</example>
		[FormPropertyName("file_comment")]
		public string FileCommentId { get; set; }

		/// <summary>
		/// Timestamp of the message to un-pin.
		/// </summary>
		/// <example>1234567890.123456</example>
		[FormPropertyName("timestamp")]
		public string MessageTimestamp { get; set; }
	}
}