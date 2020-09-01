using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SlackBot.Api.Exceptions;
using SlackBot.Api.Models;

namespace SlackBot.Api
{
    public class SlackClient : IDisposable
    {
        private static readonly Uri BaseApiUri = new Uri("https://slack.com/api/");
        private bool _disposed;

        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly HttpClient _httpClient;

        public SlackClient(string token)
        {
            _httpClient = InitHttpClient(token);
            _jsonSerializerOptions = new JsonSerializerOptions { IgnoreNullValues = true };
        }

        public Task<MessageResponse> PostMessage(Message message)
        {
            var stringContent = GetStringContent(message);

            return SendPostAsync<MessageResponse>("chat.postMessage", stringContent);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private async Task<TResponse> SendPostAsync<TResponse>(string path, HttpContent content)
            where TResponse : SlackResponseBase
        {
            var response = await _httpClient.PostAsync(new Uri(BaseApiUri, path), content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var slackApiResponse = ParseResponse<TResponse>(responseContent);
            
            return slackApiResponse;
        }
        
        private TResponse ParseResponse<TResponse>(string responseContent)
            where TResponse : SlackResponseBase
        {
            var slackApiResponse = JsonSerializer.Deserialize<TResponse>(responseContent);
            if (!slackApiResponse.Ok)
            {
                throw new SlackApiResponseException(responseContent);
            }

            return slackApiResponse;
        }
        
        private StringContent GetStringContent<TRequest>(TRequest request)
            where TRequest : class
        {
            var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            return jsonContent;
        }
        
        private FormUrlEncodedContent GetFormContent<TRequest>(TRequest request)
            where TRequest : class
        {
            var dataDictionary = ConvertToDictionary(request);
            var content = new FormUrlEncodedContent(dataDictionary);
            
            return content;
        }

        private HttpClient InitHttpClient(string token)
        {
            var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 }; 
            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }
        
        private Dictionary<string, string> ConvertToDictionary<T>(T model)
            => model.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(property => property.Name, property => property.GetValue(model)?.ToString());
        

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }
                
                _disposed = true;
            }
        }
    }
}