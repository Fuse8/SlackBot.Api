using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
    public class SlackErrorResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("warning")]
        public string Warning { get; set; }
    }
}