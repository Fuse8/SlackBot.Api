using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Tests.Helpers;

namespace SlackBot.Tests.PostMessageTests
{
	internal class ApiParametersTests
	{
		[Test]
		public async Task RequestParametersAreCorrect()
		{
			var httpRequestMessage = await SlackClientMockHelpers.GetApiRequest(new Message(), (slackClient, requestModel) => slackClient.PostMessage(requestModel));
			
			Assert.AreEqual(HttpMethod.Post, httpRequestMessage.Method);
			Assert.AreEqual("application/json", httpRequestMessage.Content.Headers.ContentType.MediaType);
			Assert.That("/chat.postmessage", Is.EqualTo(httpRequestMessage.RequestUri.AbsolutePath).IgnoreCase);
		}
		
		[Test]
		public async Task MessageRequestContentSetsCorrectly()
		{
			var message = new Message { Channel = "channel" };
			var expectedRequest = message.ToJson();
			
			var httpRequestMessage = await SlackClientMockHelpers.GetApiRequest(message, (slackClient, requestModel) => slackClient.PostMessage(requestModel));
			var requestContent = await httpRequestMessage.Content.ReadAsStringAsync();

			Assert.AreEqual(expectedRequest, requestContent);
		}
	}
}