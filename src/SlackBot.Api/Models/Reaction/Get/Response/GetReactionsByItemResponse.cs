using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Message;

namespace SlackBot.Api.Models.Reaction.Get.Response
{
	public class GetReactionsByItemResponse : SlackBaseResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }
		
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public MessageResponse Message { get; set; }

		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}