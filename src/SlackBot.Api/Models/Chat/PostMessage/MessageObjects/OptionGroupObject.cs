using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects
{
	public class OptionGroupObject
	{
		[JsonProperty("label")]
		public PlainTextObject Label { get; set; }
		
		[JsonProperty("options")]
		public OptionObject[] Options { get; set; }
	}
}