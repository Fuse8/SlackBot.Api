namespace SlackBot.Api
{
	public class RemoteFileToRemove : RemoteFileBaseRequest
	{
		public RemoteFileToRemove()
		{
		}
		
		public RemoteFileToRemove(string fileId = null, string externalId = null)
			: base(fileId, externalId)
		{
		}
	}
}