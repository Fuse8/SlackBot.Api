using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Contracts
{
	public interface IObjectWithType
	{
		[JsonProperty("type")]
		string Type { get; }
	}
}