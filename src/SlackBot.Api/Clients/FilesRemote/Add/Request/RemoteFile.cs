using System;
using System.IO;
using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class RemoteFile
	{
		public RemoteFile()
		{
		}

		public RemoteFile(
			string externalId,
			Uri externalUrl,
			string title = null,
			Stream previewImageStream = null,
			string fileType = null,
			Stream indexableContentStream = null)
		{
			ExternalId = externalId;
			ExternalUrl = externalUrl;
			Title = title;
			PreviewImageStream = previewImageStream;
			FileType = fileType;
			IndexableContentStream = indexableContentStream;
		}

		/// <summary>
		/// Creator defined GUID for the file.
		/// </summary>
		/// <example>123456</example>
		[FormPropertyName("external_id")]
		public string ExternalId { get; set; }

		/// <summary>
		/// URL of the remote file.
		/// </summary>
		/// <example>http://example.com/my_cloud_service_file/abc123</example>
		[FormPropertyName("external_url")]
		public Uri ExternalUrl { get; set; }

		/// <summary>
		/// Title of the file being shared.
		/// </summary>
		/// <example>Danger, High Voltage!</example>
		[FormPropertyName("title")]
		public string Title { get; set; }

		/// <summary>
		/// Type of file
		/// </summary>
		/// <example>doc</example>
		[FormPropertyName("filetype")]
		public string FileType { get; set; }

		/// <summary>
		/// A text file (txt, pdf, doc, etc.) containing textual search terms that are used to improve discovery of the remote file.
		/// </summary>
		[FormPropertyName("indexable_file_contents")]
		public Stream IndexableContentStream { get; set; }

		/// <summary>
		/// Preview of the document.
		/// </summary>
		[FormPropertyName("preview_image")]
		public Stream PreviewImageStream { get; set; }
	}
}