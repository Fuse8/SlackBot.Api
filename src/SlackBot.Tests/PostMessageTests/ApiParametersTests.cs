using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SlackBot.Api.Clients;
using SlackBot.Tests.Helpers;

namespace SlackBot.Tests.PostMessageTests
{
	internal class ApiParametersTests
	{
		[Test]
		public async Task RequestParametersAreCorrectAsync()
		{
			var httpRequestMessage = await SlackClientMockHelpers.GetApiRequestAsync(new Message(), (slackClient, requestModel) => slackClient.Chat.PostMessageAsync(requestModel));
			
			Assert.AreEqual(HttpMethod.Post, httpRequestMessage.Method);
			Assert.AreEqual("application/json", httpRequestMessage.Content.Headers.ContentType.MediaType);
			Assert.That("/chat.postmessage", Is.EqualTo(httpRequestMessage.RequestUri.AbsolutePath).IgnoreCase);
		}
	}
}