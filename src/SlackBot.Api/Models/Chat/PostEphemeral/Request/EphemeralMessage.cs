using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.MessageAttachment;

namespace SlackBot.Api.Models.Chat.PostEphemeral.Request
{
	public class EphemeralMessage : MessageBase
	{
		public EphemeralMessage()
		{
		}

		public EphemeralMessage(string channelIdOrName, string userId, string text = null, Attachment[] attachments = null, BlockBase[] blocks = null)
			: base(channelIdOrName, text, attachments, blocks)
		{
			UserId = userId;
		}

		/// <summary>
		/// Id of the user who will receive the ephemeral message.
		/// The user should be in the channel specified by the <see cref="MessageBase.ChannelIdOrName"/> argument.
		/// </summary>
		[JsonProperty("user")]
		public string UserId { get; set; }
	}
}