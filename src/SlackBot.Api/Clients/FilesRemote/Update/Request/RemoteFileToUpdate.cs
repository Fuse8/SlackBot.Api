using System;
using System.IO;
using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class RemoteFileToUpdate : RemoteFile
	{
		public RemoteFileToUpdate()
		{
		}

		public RemoteFileToUpdate(
			string fileId = null,
			Uri externalUrl = null,
			string title = null,
			Stream previewImageStream = null,
			string fileType = null,
			Stream indexableContentStream = null,
			string externalId = null)
			: base(externalId, externalUrl, title, previewImageStream, fileType, indexableContentStream)
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