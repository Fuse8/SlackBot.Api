using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.File;
using SlackBot.Api.Models.GeneralObjects.Message;

namespace SlackBot.Api.Models.Reaction.Get.Response
{
	public class ReactionsByItemResponse : SlackFileResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }
		
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public MessageResponse Message { get; set; }
	}
}