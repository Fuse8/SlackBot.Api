using Newtonsoft.Json;

namespace SlackBot.Api
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