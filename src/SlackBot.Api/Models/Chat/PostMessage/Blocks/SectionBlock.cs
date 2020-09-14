using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class SectionBlock : BlockBase
	{
		protected override string SectionType => "section";
		
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }
		
		[JsonProperty("fields")]
		public TextObjectBase[] Fields { get; set; }

		[JsonProperty("accessory")]
		public ISectionElement Accessory { get; set; }
	}
}