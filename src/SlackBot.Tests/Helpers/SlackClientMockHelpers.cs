using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using Moq.Protected;
using SlackBot.Api.Clients;

namespace SlackBot.Tests.Helpers
{
	internal class SlackClientMockHelpers
	{
		public static async Task<HttpRequestMessage> GetApiRequestAsync<TRequest, TResponse>(TRequest request, Func<SlackClient, TRequest, Task<TResponse>> apiMethod)
		{
			HttpRequestMessage requestMessage = null;	
			using (var slackClient = GetSlackClient(s => requestMessage = s))
			{
				await apiMethod(slackClient, request);
			}
			
			return requestMessage;
		}

		private static SlackClient GetSlackClient(Action<HttpRequestMessage> requestCallback)
		{
			var httpMessageHandler = new Mock<HttpMessageHandler>();
			var fixture = new Fixture();

			httpMessageHandler.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>()
				)
				.ReturnsAsync(
					(HttpRequestMessage request, CancellationToken token) =>
					{
						requestCallback(request);
						var response = new HttpResponseMessage
						{
							StatusCode = HttpStatusCode.OK,
							Content = new StringContent(@"{""ok"":true}")
						};

						response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
						return response;
					});

			var httpClient = new HttpClient(httpMessageHandler.Object) {BaseAddress = fixture.Create<Uri>()};

			return new SlackClient(httpClient);
		}
	}
}