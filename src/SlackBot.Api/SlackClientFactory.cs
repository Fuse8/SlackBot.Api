using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace SlackBot.Api
{
	public static class SlackClientFactory
	{
		private static readonly Uri BaseApiUri = new Uri("https://slack.com/api/");

		public static SlackClient CreateSlackClient(string token)
		{
			var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 }; 
			var httpClient = new HttpClient(httpClientHandler) { BaseAddress = BaseApiUri };
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			
			var slackClient = new SlackClient(httpClient);
			return slackClient;
		}
	}
}