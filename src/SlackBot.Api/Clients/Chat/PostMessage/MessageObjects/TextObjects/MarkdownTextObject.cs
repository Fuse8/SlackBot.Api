using Newtonsoft.Json;
using SlackBot.Api.Clients.PostMessage.Contracts;

namespace SlackBot.Api.Clients.PostMessage.MessageObjects.TextObjects
{
	public class MarkdownTextObject : TextObjectBase
	{
		protected override string SectionType => "mrkdwn";

		/// <summary>
		/// When set to false URLs will be auto-converted into links, conversation names will be link-field, and certain mentions will be automatically parsed.
		/// Using a value of "true" will skip any preprocessing of this nature, although you can still include manual parsing strings.
		/// This field is only usable when <see cref="ObjectWithType.Type"/> is "mrkdwn".
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		[JsonProperty("verbatim")]
		public bool? Verbatim { get; set; }
		
		public static implicit operator MarkdownTextObject(string text)
			=> new MarkdownTextObject
			{
				Text = text,
			};
	}
}