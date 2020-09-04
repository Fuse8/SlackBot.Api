using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Sections
{
	public abstract class SectionBase
	{
		protected abstract string SectionType { get; }

		[JsonProperty("type")]
		public string Type => SectionType;
	}
}