using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections
{
	public abstract class SectionBase
	{
		protected abstract string SectionType { get; }

		[JsonProperty("type")]
		public string Type => SectionType;
	}
}