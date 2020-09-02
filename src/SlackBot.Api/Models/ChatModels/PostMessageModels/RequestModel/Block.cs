namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel
{
	public class Block // todo abstract 
	{
		public string Type { get; set; }

		public object[] Elements { get; set; } 

		public string BlockId { get; set; }
	}
}