using System.IO;
using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.File.Upload.Request
{
    public class FileToUpload : FileToUploadBase
    {
        [FormPropertyName("file")]
        public Stream Stream { get; set; }
    }
}