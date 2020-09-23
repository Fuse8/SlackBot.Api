using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.Message
{
    public class PinnedInfo
    {
        [JsonProperty("channel")]
        public string ChannelId { get; set; }

        [JsonProperty("pinned_by")]
        public string PinnedById { get; set; }

        [JsonProperty("pinned_ts")]
        public long PinnedTimestamp { get; set; }
    }
}