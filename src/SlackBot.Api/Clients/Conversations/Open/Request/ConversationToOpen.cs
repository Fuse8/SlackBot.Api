using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class ConversationToOpen
	{
		public ConversationToOpen()
		{
		}
		
		public ConversationToOpen(string userIds, bool? returnFillDirectMessageInfo = null)
		{
			UserIds = userIds;
			ReturnFillDirectMessageInfo = returnFillDirectMessageInfo;
		}

		/// <summary>
		/// Resume a conversation by supplying an "im" or "mpim's" ID. Or provide the <see cref="UserIds"/> field instead.
		/// </summary>
		/// <example>G1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Boolean, indicates you want the full IM channel definition in the response.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("return_im")]
		public bool? ReturnFillDirectMessageInfo { get; set; }

		/// <summary>
		/// Comma separated lists of users. If only one user is included, this creates a 1:1 DM.
		/// The ordering of the users is preserved whenever a multi-person direct message is returned.
		/// Supply a <see cref="ChannelId"/> when not supplying <see cref="UserIds"/>.
		/// </summary>
		/// <example>W1234567890,U2345678901,U3456789012</example>
		[FormPropertyName("users")]
		public string UserIds { get; set; }
	}
}