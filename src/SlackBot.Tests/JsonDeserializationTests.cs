using NUnit.Framework;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Tests
{
	public class JsonDeserializationTests
	{
		[Test]
		public void Test1()
		{
			var json = @"{""type"":""some_unknown_type""}";
			var block = json.FromJson<BlockBase>();

			Assert.IsInstanceOf(typeof(UnknownObject), block);
		}
	}
}