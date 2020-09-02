using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SlackBot.Api.Exceptions;
using SlackBot.Api.Models;
using SlackBot.Api.Models.UploadFile.RequestModels;
using SlackBot.Api.Models.UploadFile.ResponseModels;

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

        public Task<UploadFileResponse> UploadContent(ContentMessage contentMessage)
        {
            var stringContent = GetFormContent(contentMessage);

            return SendPostAsync<UploadFileResponse>("files.upload", stringContent);
        }
        
        public Task<UploadFileResponse> UploadFile(FileMessage fileMessageMessage)
        {
            var multipartContent = new MultipartFormDataContent
            {
                { new StreamContent(fileMessageMessage.file), "file", fileMessageMessage.filename } //TODO get name "file" from attribute of property FileMessage.file
            };

            var dataDictionary = ConvertToDictionary(fileMessageMessage, nameof(FileMessage.file), nameof(FileMessage.filename));
            foreach (var propertyData in dataDictionary)
            {
                var dataValue = propertyData.Value;
                if (dataValue != null)
                {
                    multipartContent.Add(new StringContent(dataValue), propertyData.Key);
                }
            }

            return SendPostAsync<UploadFileResponse>("files.upload", multipartContent); //TODO сделать константы для урлов
        }
        

        public Task<MessageResponse> PostMessage(Message message)
        {
            var stringContent = GetFormContent(message);

            return SendPostAsync<MessageResponse>("files.upload", stringContent);
        }
        
        public Task<ConversationResponse> UserConversations(UserConversations message)
        {
            return SendGetAsync<UserConversations, ConversationResponse>("users.conversations", message);
        }
        
        public Task<UploadFileResponse> UploadFile(UploadFile message)
        {
            var multipartFormDataContent = new MultipartFormDataContent();
            if (message.File != default)
            {
                var content = new StreamContent(message.File);
                multipartFormDataContent.Add(content, "file", message.File.Name);
            }

            var queryParams = GetQueryParams(message);
            var filesUploadUrl = $"files.upload{(string.IsNullOrWhiteSpace(queryParams) ? string.Empty : $"?{queryParams}")}";
            return SendPostAsync<UploadFileResponse>(filesUploadUrl, multipartFormDataContent);
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
        
        private Task<TResponse> SendGetAsync<TRequest, TResponse>(string path, TRequest request)
            where TResponse : SlackResponseBase
        {
            var queryParams = GetQueryParams(request);

            return SendGetAsync<TResponse>($"{path}?{queryParams}");
        }
        
        private async Task<TResponse> SendGetAsync<TResponse>(string path)
            where TResponse : SlackResponseBase
        {
            var response = await _httpClient.GetAsync(new Uri(BaseApiUri, path));
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
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            return stringContent;
        }

        private string GetQueryParams<TRequest>(TRequest request)
        {
            var dataDictionary = ConvertToDictionary(request);
            var formUrlEncodedContent = new FormUrlEncodedContent(dataDictionary);
            
            return formUrlEncodedContent;
        }
        
        private HttpClient InitHttpClient(string token)
        {
            var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 }; 
            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }

        private Dictionary<string, string> ConvertToDictionary<T>(T model, params string[] excludedProperties)
            => model.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(propertyInfo => !excludedProperties.Contains(propertyInfo.Name))
                .ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(model)?.ToString());
        

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