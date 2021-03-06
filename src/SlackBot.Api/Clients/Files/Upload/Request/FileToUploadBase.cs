﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public abstract class FileToUploadBase
	{
		protected FileToUploadBase()
		{
		}

		protected FileToUploadBase(string channelNamesOrIds, string filename, string comment, string title, string fileType, string threadTimestamp)
		{
			ChannelNamesOrIds = channelNamesOrIds;
			Filename = filename;
			Comment = comment;
			Title = title;
			FileType = fileType;
			ThreadTimestamp = threadTimestamp;
		}

		/// <summary>
		/// Comma-separated list of channel names or IDs where the file will be shared.
		/// </summary>
		/// <example>C1234567890,C2345678901,C3456789012</example>
		[FormPropertyName("channels")]
		public string ChannelNamesOrIds { get; set; }

		/// <summary>
		/// Filename of file.
		/// </summary>
		/// <example>foo.txt</example>
		[FormPropertyName("filename")]
		public string Filename { get; set; }

		/// <summary>
		/// A file type identifier.
		/// </summary>
		/// <example>php</example>
		[FormPropertyName("filetype")]
		public string FileType { get; set; }

		/// <summary>
		/// The message text introducing the file in specified <see cref="ChannelNamesOrIds"/>.
		/// </summary>
		/// <example>Best!</example>
		[FormPropertyName("initial_comment")]
		public string Comment { get; set; }

		/// <summary>
		/// Title of file.
		/// </summary>
		/// <example>My File</example>
		[FormPropertyName("title")]
		public string Title { get; set; }

		/// <summary>
		/// Provide another message's "ts" value to upload this file as a reply. Never use a reply's "ts" value; use its parent instead.
		/// </summary>
		/// <example>1234567890.123456</example>
		[FormPropertyName("thread_ts")]
		public string ThreadTimestamp { get; set; }
	}
}