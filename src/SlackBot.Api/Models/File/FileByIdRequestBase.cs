using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.File
{
	public abstract class FileByIdRequestBase
	{
		protected FileByIdRequestBase()
		{
		}

		protected FileByIdRequestBase(string fileId)
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