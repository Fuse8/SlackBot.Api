using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects
{
	public abstract class TextObjectBase : ObjectWithType, IInputElement, IContextElement
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("verbatim")]
		public bool? Verbatim { get; set; }
	}
}