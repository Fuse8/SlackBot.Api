using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects
{
	public class MrkdwnTextObject : TextObjectBase
	{
		protected override string SectionType => "mrkdwn";

		[JsonProperty("verbatim")]
		public bool?  Verbatim { get; set; }
		
		public static implicit operator MrkdwnTextObject(string text) =>
			new MrkdwnTextObject
			{
				Text = text
			};
	}
}