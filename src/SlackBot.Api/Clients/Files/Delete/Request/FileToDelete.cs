using SlackBot.Api.Attributes;

namespace SlackBot.Api
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
		/// Specify a file by providing its ID.
		/// </summary>
		/// <example>F2147483862</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }
	}
}