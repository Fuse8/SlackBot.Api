namespace SlackBot.Api.Models.File.Delete.Request
{
	public class FileToDelete : FileByIdRequestBase
	{
		public FileToDelete()
		{
		}

		public FileToDelete(string fileId)
			: base(fileId)
		{
		}
	}
}