using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.FileModels.UploadModels.RequestModels
{
    public class ContentToUpload : FileToUploadBase
    {
        [FormPropertyName("content")]
        public string Content { get; set; }
    }
}