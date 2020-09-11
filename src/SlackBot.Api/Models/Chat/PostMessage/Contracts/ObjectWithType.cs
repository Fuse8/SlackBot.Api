using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Contracts
{
	public abstract class ObjectWithType : IObjectWithType
	{
		protected abstract string SectionType { get; }

		[JsonProperty("type")]
		public string Type => SectionType;
	}
}