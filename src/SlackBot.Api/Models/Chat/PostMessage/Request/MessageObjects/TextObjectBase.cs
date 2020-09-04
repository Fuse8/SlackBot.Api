using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects
{
	public abstract class TextObjectBase : ObjectWithType, IInputElement, IContextElement
	{
		[JsonProperty("text")]
		public string Text { get; set; }
		
		[JsonProperty("verbatim")]
		public bool?  Verbatim { get; set; }
	}
}