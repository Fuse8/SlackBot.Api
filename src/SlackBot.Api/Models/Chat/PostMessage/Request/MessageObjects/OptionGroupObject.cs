using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects
{
	public class OptionGroupObject
	{
		[JsonProperty("label")]
		public PlainTextObject Label { get; set; }
		
		[JsonProperty("options")]
		public OptionObject[] Options { get; set; }
	}
}