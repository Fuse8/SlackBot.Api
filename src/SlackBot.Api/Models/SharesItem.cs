using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
    public class SharesItem
    {
        [JsonPropertyName("reply_users")]
        public object[] ReplyUsers { get; set; }

        [JsonPropertyName("reply_users_count")]
        public long ReplyUsersCount { get; set; }

        [JsonPropertyName("reply_count")]
        public long ReplyCount { get; set; }

        [JsonPropertyName("ts")]
        public string ThreadId { get; set; }

        [JsonPropertyName("channel_name")]
        public string ChannelName { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [JsonPropertyName("share_user_id")]
        public string ShareUserId { get; set; }
    }
}