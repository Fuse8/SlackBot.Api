using SlackBot.Api.Attributes;
using SlackBot.Api.Clients.Add.Request;

namespace SlackBot.Api.Clients.Update.Request
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