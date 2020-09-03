using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SlackBot.Api.Exceptions;
using SlackBot.Api.Helpers;
using SlackBot.Api.Models;
using SlackBot.Api.Models.ChatModels.PostMessageModels;
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
            var nameOfFileStreamProperty = nameof(FileToUpload.FileStream);
            var fileFormPropertyName = FormPropertyHelper.GetFormPropertyName<FileToUpload>(nameOfFileStreamProperty);
            
            var multipartContent = new MultipartFormDataContent
            {
                { new StreamContent(fileToUpload.FileStream), fileFormPropertyName, fileToUpload.FileStream.Name }
            };

            var dataDictionary = ConvertToDictionary(fileToUpload, nameOfFileStreamProperty);
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
            var url = CustomUrlHelper.BuildUrl(BaseApiUri, path);
            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var slackApiResponse = ParseResponse<TResponse>(responseContent);
            
            return slackApiResponse;
        }
        
        private async Task<TResponse> SendGetAsync<TRequest, TResponse>(string path, TRequest request)
            where TResponse : SlackResponseBase
            where TRequest : class
        {
            var queryParamsDictionary = FormPropertyHelper.GetFormProperties(request).ToDictionary(p => p.PropertyName, p => p.PropertyValue);
            var url = CustomUrlHelper.BuildUrl(BaseApiUri, path, queryParamsDictionary);
            
            var response = await _httpClient.GetAsync(url);
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
        
        private HttpClient InitHttpClient(string token)
        {
            var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 }; 
            var httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }

        private Dictionary<string, string> ConvertToDictionary<T>(T model, params string[] excludedProperties)
            => FormPropertyHelper.GetFormProperties(model)
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