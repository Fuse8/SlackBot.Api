﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.Message
{
    public class MessageReactionItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("count")]
        public long Count { get; set; }
        
        [JsonProperty("users")]
        public List<string> UserIds { get; set; }
    }
}