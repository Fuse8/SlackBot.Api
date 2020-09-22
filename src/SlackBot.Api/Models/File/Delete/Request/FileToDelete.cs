using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.File.Delete.Request
{
	public class FileToDelete
	{
		public FileToDelete()
		{
		}

		public FileToDelete(string fileId)
		{
			FileId = fileId;
		}

		/// <summary>
		/// ID of file to delete.
		/// </summary>
		/// <example>F1234567890</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }
	}
}