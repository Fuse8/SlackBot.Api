using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class BotIconItem
    {
        [JsonPropertyName("image_36")]
        public Uri Image36Url { get; set; }

        [JsonPropertyName("image_48")]
        public Uri Image48Url { get; set; }

        [JsonPropertyName("image_72")]
        public Uri Image72Url { get; set; }
    }
}