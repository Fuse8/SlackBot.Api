using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class BotIconItem
    {
        [JsonProperty("image_36")]
        public Uri Image36Url { get; set; }

        [JsonProperty("image_48")]
        public Uri Image48Url { get; set; }

        [JsonProperty("image_72")]
        public Uri Image72Url { get; set; }
    }
}