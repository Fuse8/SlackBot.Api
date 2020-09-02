namespace SlackBot.Api.Models.UploadFile.RequestModels
{
    public abstract class FileBase
    {
        public string channels { get; set; }

        public string filename { get; set; }

        public string filetype { get; set; }

        public string initial_comment { get; set; }

        public string ThreadId { get; set; }

        public string title { get; set; }
    }
}