using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections
{
	public class ConfirmSection
	{
		[JsonProperty("text")]
		public PlainTextSection Text { get; set; }

		[JsonProperty("title")]
		public PlainTextSection Title { get; set; }

		[JsonProperty("confirm")]
		public PlainTextSection Confirm { get; set; }

		[JsonProperty("deny")]
		public PlainTextSection Deny { get; set; }
	}
}