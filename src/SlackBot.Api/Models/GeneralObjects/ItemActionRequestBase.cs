using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.GeneralObjects
{
	public abstract class ItemActionRequestBase
	{
		protected ItemActionRequestBase()
		{
		}

		protected ItemActionRequestBase(string channelId, string messageTimestamp)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
		}

		/// <summary>
		/// Channel where the message was posted.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Timestamp of the message do action with.
		/// </summary>
		/// <example>1234567890.123456</example>
		[FormPropertyName("timestamp")]
		public string MessageTimestamp { get; set; }

		/// <summary>
		/// File to do action with.
		/// </summary>
		/// <example>F1234567890</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }

		/// <summary>
		/// File comment to do action with.
		/// </summary>
		/// <example>Fc1234567890</example>
		[FormPropertyName("file_comment")]
		public string FileCommentId { get; set; }
	}
}