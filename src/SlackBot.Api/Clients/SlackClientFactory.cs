﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace SlackBot.Api
{
	public static class SlackClientFactory
	{
		private static readonly Uri _baseApiUri = new Uri("https://slack.com/api/");

		public static SlackClient CreateSlackClient(string token)
		{
			var httpClient = CreateHttpClient(token);

			return new SlackClient(httpClient);
		}
		
		public static TClient CreateClient<TClient>(string token)
			where TClient : SlackClientBase
		{
			var httpClient = CreateHttpClient(token);

			return (TClient)Activator.CreateInstance(typeof(TClient), httpClient);
		}
		
		public static TClient CreateClient<TClient>(HttpClient httpClient)
			where TClient : SlackClientBase
			=> (TClient)Activator.CreateInstance(typeof(TClient), httpClient);

		private static HttpClient CreateHttpClient(string token)
		{
			var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 };
			var httpClient = new HttpClient(httpClientHandler) { BaseAddress = _baseApiUri };
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			return httpClient;
		}
	}
}