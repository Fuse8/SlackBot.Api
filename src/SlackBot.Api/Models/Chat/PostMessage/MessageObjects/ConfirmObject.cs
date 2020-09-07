using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects
{
	public class ConfirmObject
	{
		[JsonProperty("text")]
		public PlainTextObject Text { get; set; }

		[JsonProperty("title")]
		public PlainTextObject Title { get; set; }

		[JsonProperty("confirm")]
		public PlainTextObject Confirm { get; set; }

		[JsonProperty("deny")]
		public PlainTextObject Deny { get; set; }
	}
}