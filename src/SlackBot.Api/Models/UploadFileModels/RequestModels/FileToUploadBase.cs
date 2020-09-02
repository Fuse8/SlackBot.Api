using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.UploadFileModels.RequestModels
{
    public abstract class FileToUploadBase // TODO maybe make protected
    {
        [FormPropertyName("channels")]
        public string Channels { get; set; } //TODO make chanel list

        [FormPropertyName("filename")]
        public string Filename { get; set; }

        [FormPropertyName("filetype")]
        public string FileType { get; set; } = "auto"; //TODO move to constants

        [FormPropertyName("initial_comment")]
        public string Comment { get; set; }

        [FormPropertyName("title")]
        public string Title { get; set; }
		
        [FormPropertyName("thread_ts")]
        public string ThreadId { get; set; }
    }
}