using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.Reaction.Get.Request
{
	public class GetReactionsRequest
	{
		public GetReactionsRequest()
		{
		}

		public GetReactionsRequest(string channelId, string messageTimestamp)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
		}

		/// <summary>
		/// Channel where the message to get reactions for was posted.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// File to get reactions for.
		/// </summary>
		/// <example>F1234567890</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }

		/// <summary>
		/// File comment to get reactions for.
		/// </summary>
		/// <example>Fc1234567890</example>
		[FormPropertyName("file_comment")]
		public string FileCommentId { get; set; }

		/// <summary>
		/// If "true" always return the complete reaction list.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("full")]
		public bool? Full { get; set; }

		/// <summary>
		/// Timestamp of the message to get reactions for.
		/// </summary>
		/// <example>1234567890.123456</example>
		[FormPropertyName("timestamp")]
		public string MessageTimestamp { get; set; }
	}
}