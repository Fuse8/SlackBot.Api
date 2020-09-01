using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
    public abstract class SlackResponseBase
    {
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }
    }
}