using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Contracts
{
	public abstract class ObjectWithType
	{
		protected abstract string SectionType { get; }

		[JsonProperty("type")]
		public string Type => SectionType;
	}
}