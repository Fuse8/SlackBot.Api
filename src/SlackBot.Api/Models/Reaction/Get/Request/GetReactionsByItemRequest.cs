using SlackBot.Api.Attributes;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Reaction.Get.Request
{
	public class GetReactionsByItemRequest : ItemActionRequestBase
	{
		public GetReactionsByItemRequest()
		{
		}

		public GetReactionsByItemRequest(string channelId, string messageTimestamp)
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