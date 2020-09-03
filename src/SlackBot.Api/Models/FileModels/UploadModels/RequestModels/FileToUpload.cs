using System.IO;
using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.FileModels.UploadModels.RequestModels
{
    public class FileToUpload : FileToUploadBase
    {
        [FormPropertyName("file")]
        public Stream Stream { get; set; }
    }
}