using System.IO;

namespace SlackBot.Api.Models.UploadFile.RequestModels
{
    public class FileMessage : FileBase
    {
        public Stream file { get; set; }
    }
}