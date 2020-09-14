﻿using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;
using SlackBot.Api.Exceptions;
using SlackBot.Api.Helpers;
using SlackBot.Api.Models;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;
using SlackBot.Api.Enums;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models.Chat.PostMessage;

namespace SlackBot.Api
{
    public class SlackClient : IDisposable
    {
        private static readonly Uri BaseApiUri = new Uri("https://slack.com/api/");
        private bool _disposed;

        private readonly HttpClient _httpClient;

        public SlackClient(string token)
        {
            _httpClient = InitHttpClient(token);
        }

        public Task<UploadFileResponse> UploadContent(ContentToUpload contentToUpload) 
            => SendPostMultipartFormAsync<ContentToUpload, UploadFileResponse>("files.upload", contentToUpload);

        public Task<UploadFileResponse> UploadFile(FileToUpload fileToUpload) 
            => SendPostMultipartFormAsync<FileToUpload, UploadFileResponse>("files.upload", fileToUpload);
        
        public Task<PostMessageResponse> PostMessage(Message message) 
            => SendPostJsonStringAsync<Message, PostMessageResponse>("chat.postMessage", message);

        public Task<ConversationResponse> UserConversations(UserConversations message) 
            => SendGetAsync<UserConversations, ConversationResponse>("users.conversations", message);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private Task<TResponse> SendPostJsonStringAsync<TRequest, TResponse>(string path, TRequest request)
            where TRequest : class 
            where TResponse : SlackResponseBase 
            => SendPostAsync<TRequest, TResponse>(path, request, HttpContentHelper.GetJsonStringContent);
        
        private Task<TResponse> SendPostFormUrlEncodedAsync<TRequest, TResponse>(string path, TRequest request)
            where TRequest : class 
            where TResponse : SlackResponseBase 
            => SendPostAsync<TRequest, TResponse>(path, request, HttpContentHelper.GetFormUrlEncodedContent);    
        
        private Task<TResponse> SendPostMultipartFormAsync<TRequest, TResponse>(string path, TRequest request)
            where TRequest : class 
            where TResponse : SlackResponseBase 
            => SendPostAsync<TRequest, TResponse>(path, request, HttpContentHelper.GetMultipartForm);

        private async Task<TResponse> SendPostAsync<TRequest, TResponse>(string path, TRequest request, Func<TRequest, HttpContent> getHttpContext)
            where TResponse : SlackResponseBase
        {
            var httpContext = getHttpContext(request);
            var response = await _httpClient.PostAsync(path, httpContext);
            var slackApiResponse = await ParseResponseAsync<TResponse>(response);
            
            return slackApiResponse;
        } 
        
        private async Task<TResponse> SendGetAsync<TRequest, TResponse>(string path, TRequest request)
            where TResponse : SlackResponseBase
            where TRequest : class
        {
            var queryParamsDictionary = FormPropertyHelper.GetFormProperties(request).ToDictionary(p => p.PropertyName, p => p.PropertyValue);
            var url = CustomUrlHelper.CreateQueryString(path, queryParamsDictionary);
            
            var response = await _httpClient.GetAsync(url); 
            var slackApiResponse = await ParseResponseAsync<TResponse>(response);
            
            return slackApiResponse;
        }

        private async Task<TResponse> ParseResponseAsync<TResponse>(HttpResponseMessage response)
            where TResponse : SlackResponseBase
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var slackApiResponse = responseContent.FromJson<TResponse>(ExceptionHandlingMode.DoNotProcess);
            if (slackApiResponse?.Ok != true)
            {
                throw new SlackApiResponseException(responseContent);
            }

            return slackApiResponse;
        }

        private HttpClient InitHttpClient(string token)
        {
            var httpClientHandler = new HttpClientHandler { SslProtocols = SslProtocols.Tls12 }; 
            var httpClient = new HttpClient(httpClientHandler) { BaseAddress = BaseApiUri };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return httpClient;
        }

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
