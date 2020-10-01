using Newtonsoft.Json;
using SlackBot.Api.Clients.PostMessage.Contracts;
using SlackBot.Api.Clients.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Clients.PostMessage.MessageObjects.TextObjects
{
	public abstract class TextObjectBase : ObjectWithType, IInputElement, IContextElement
	{
		/// <summary>
		/// The text for the block. This field accepts any of the standard text formatting markup when <see cref="TextObjectBase.Type"/> is "mrkdwn".
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}