using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace SlackBot.Api.Helpers
{
	public static class HttpClientHelpers
	{
		private static readonly Uri BaseApiUri = new Uri("https://slack.com/api/");

		public static HttpClient GetSlackHttpClient(string token)
		{
			var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 }; 
			var httpClient = new HttpClient(httpClientHandler) { BaseAddress = BaseApiUri };
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			return httpClient;
		}
	}
}