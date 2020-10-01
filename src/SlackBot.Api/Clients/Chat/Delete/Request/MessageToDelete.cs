using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients.Delete.Request
{
	public class MessageToDelete
	{
		public MessageToDelete()
		{
		}

		public MessageToDelete(string channelId, string messageTimestamp)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
		}

		/// <summary>
		/// Channel containing the message to be deleted.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Timestamp of the message to be deleted.
		/// </summary>
		/// <example>1405894322.002768</example>
		[FormPropertyName("ts")]
		public string MessageTimestamp { get; set; }

		/// <summary>
		/// Pass "true" to delete the message as the authed user with "chat:write:user" scope. Bot users in this context are considered authed users.
		/// If unused or "false", the message will be deleted with "chat:write:bot" scope.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("as_user")]
		public bool? AsUser { get; set; }
	}
}