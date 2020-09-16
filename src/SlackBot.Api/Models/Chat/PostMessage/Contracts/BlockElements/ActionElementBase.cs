using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements
{
	public abstract class ActionElementBase : ObjectWithType
	{
		[JsonProperty("action_id")]
		public string ActionId { get; set; }

		[JsonProperty("confirm")]
		public ConfirmObject Confirm { get; set; }
	}
}