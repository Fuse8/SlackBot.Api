using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Contracts
{
	public abstract class BlockBase : ObjectWithType
	{
		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}