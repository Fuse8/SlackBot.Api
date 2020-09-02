using System.IO;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
	public class UploadFile
	{
		[JsonPropertyName("channels")]
		public string Channels { get; set; }

		[JsonPropertyName("content")]
		public string Content { get; set; }

		[JsonPropertyName("filename")]
		public string Filename { get; set; }

		[JsonPropertyName("filetype")]
		public string FileType { get; set; }

		[JsonPropertyName("initial_comment")]
		public string InitialComment { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; }
		
		[JsonPropertyName("thread_ts")]
		public string ThreadId { get; set; }

		public FileStream File { get; set; }
	}
}