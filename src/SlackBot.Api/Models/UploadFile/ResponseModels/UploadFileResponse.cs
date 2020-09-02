using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.UploadFile.ResponseModels
{
    public class UploadFileResponse : SlackResponseBase
    {
        [JsonPropertyName("file")]
        public FileResponse File { get; set; } 
    }
}