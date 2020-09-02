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
using SlackBot.Api.Attributes;
using SlackBot.Api.Exceptions;
using SlackBot.Api.Models;
using SlackBot.Api.Models.ChatModels.PostMessageModels;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel;
using SlackBot.Api.Models.FileModels.UploadModels.RequestModels;
using SlackBot.Api.Models.FileModels.UploadModels.ResponseModels;
using SlackBot.Api.Models.UserModels.ConversationModels.RequestModels;
using SlackBot.Api.Models.UserModels.ConversationModels.ResponseModels;

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

        public Task<UploadFileResponse> UploadContent(ContentToUpload contentToUpload)
        {
            var stringContent = GetFormContent(contentToUpload);

            return SendPostAsync<UploadFileResponse>("files.upload", stringContent);
        }
        
        public Task<UploadFileResponse> UploadFile(FileToUpload fileToUpload)
        {
            var multipartContent = new MultipartFormDataContent
            {
                { new StreamContent(fileToUpload.FileStream), "file", fileToUpload.FileStream.Name } //TODO get name "file" from attribute of property FileMessage.file
            };

            var dataDictionary = ConvertToDictionary(fileToUpload, nameof(FileToUpload.FileStream), nameof(FileToUpload.Filename));
            foreach (var propertyData in dataDictionary)
            {
                var dataValue = propertyData.Value;
                if (dataValue != null)
                {
                    multipartContent.Add(new StringContent(dataValue), propertyData.Key);
                }
            }

            return SendPostAsync<UploadFileResponse>("files.upload", multipartContent);
        }
        

        public Task<MessageResponse> PostMessage(Message message)
        {
            var stringContent = GetFormContent(message);

            return SendPostAsync<MessageResponse>("chat.postMessage", stringContent);
        }
        
        public Task<ConversationResponse> UserConversations(UserConversations message)
        {
            return SendGetAsync<UserConversations, ConversationResponse>("users.conversations", message);
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

        private IEnumerable<(string PropertyName, string PropertyValue)> GetFormPropertyValues<T>(T model) => //TODO возможно унести в хелпер
            model.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(
                    propertyInfo =>
                    (
                        PropertyName: propertyInfo.GetCustomAttribute<FormPropertyNameAttribute>()?.Name ?? propertyInfo.Name,
                        PropertyValue: propertyInfo.GetValue(model)?.ToString()
                    ))
                .Where(p => p.PropertyValue != null);


        private StringContent GetJsonStringContent<TRequest>(TRequest request)
            where TRequest : class
        {
            var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            return stringContent;
        }
        
        private FormUrlEncodedContent GetFormContent<TRequest>(TRequest request)
            where TRequest : class
        {
            var dataDictionary = ConvertToDictionary(request);
            var formUrlEncodedContent = new FormUrlEncodedContent(dataDictionary);
            
            return formUrlEncodedContent;
        }

        private string GetQueryParams<TRequest>(TRequest request)
        {
            var formContent = GetFormPropertyValues(request).Select(p => $"{p.PropertyName}={p.PropertyValue}");
            var queryParams = string.Join("&", formContent);
            
            return queryParams;
        }
        
        private HttpClient InitHttpClient(string token)
        {
            var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 }; 
            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }

        private Dictionary<string, string> ConvertToDictionary<T>(T model, params string[] excludedProperties)
            => GetFormPropertyValues(model)
                .Where(property => !excludedProperties.Contains(property.PropertyName))
                .ToDictionary(property => property.PropertyName, propertyInfo => propertyInfo.PropertyValue);
        

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