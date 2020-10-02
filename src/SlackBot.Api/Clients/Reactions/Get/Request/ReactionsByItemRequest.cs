using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class ReactionsByItemRequest : ItemActionRequestBase
	{
		public ReactionsByItemRequest()
		{
		}

		public ReactionsByItemRequest(string channelId, string messageTimestamp)
			: base(channelId, messageTimestamp)
		{
		}

		/// <summary>
		/// If "true" always return the complete reaction list.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("full")]
		public bool? Full { get; set; }
	}
}