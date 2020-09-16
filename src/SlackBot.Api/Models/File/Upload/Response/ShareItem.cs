using Newtonsoft.Json;

namespace SlackBot.Api.Models.File.Upload.Response
{
	public class ShareItem
	{
		[JsonProperty("reply_users")]
		public string[] ReplyUsers { get; set; }

		[JsonProperty("reply_users_count")]
		public long ReplyUsersCount { get; set; }

		[JsonProperty("reply_count")]
		public long ReplyCount { get; set; }

		[JsonProperty("ts")]
		public string ThreadId { get; set; }

		[JsonProperty("channel_name")]
		public string ChannelName { get; set; }

		[JsonProperty("team_id")]
		public string TeamId { get; set; }

		[JsonProperty("share_user_id")]
		public string ShareUserId { get; set; }

		[JsonProperty("latest_reply")]
		public string LatestReply { get; set; }
	}
}