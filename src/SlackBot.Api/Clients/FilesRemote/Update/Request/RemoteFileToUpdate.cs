using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class RemoteFileToUpdate : RemoteFile
	{
		/// <summary>
		/// Specify a file by providing its ID.
		/// </summary>
		/// <example>F2147483862</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }
	}
}