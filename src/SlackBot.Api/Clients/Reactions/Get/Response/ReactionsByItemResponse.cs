using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects.File;
using SlackBot.Api.Clients.GeneralObjects.Message;

namespace SlackBot.Api.Clients.Get.Response
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