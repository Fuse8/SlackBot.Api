using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Enums;
using SlackBot.Api.Exceptions;
using SlackBot.Api.Extensions;
using SlackBot.Api.Helpers;

namespace SlackBot.Api
{
    public abstract class SlackClientBase : DisposableObjectBase
    {
        private readonly HttpClient _httpClient;
        
        protected SlackClientBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        protected abstract string ObjectPath { get; }

        protected Task<SlackBaseResponse> SendPostJsonStringAsync<TRequest>(string path, TRequest request)
            where TRequest : class
            => SendPostJsonStringAsync<TRequest, SlackBaseResponse>(path, request);

        protected Task<TResponse> SendPostJsonStringAsync<TRequest, TResponse>(string path, TRequest request)
            where TRequest : class 
            where TResponse : SlackBaseResponse 
            => SendPostAsync<TRequest, TResponse>(path, request, HttpContentHelper.GetJsonStringContent);

        protected Task<SlackBaseResponse> SendPostFormUrlEncodedAsync<TRequest>(string path, TRequest request)
            where TRequest : class
            => SendPostFormUrlEncodedAsync<TRequest, SlackBaseResponse>(path, request);

        protected Task<TResponse> SendPostFormUrlEncodedAsync<TRequest, TResponse>(string path, TRequest request)
            where TRequest : class 
            where TResponse : SlackBaseResponse 
            => SendPostAsync<TRequest, TResponse>(path, request, HttpContentHelper.GetFormUrlEncodedContent);    
        
        protected Task<TResponse> SendPostMultipartFormAsync<TRequest, TResponse>(string path, TRequest request)
            where TRequest : class 
            where TResponse : SlackBaseResponse 
            => SendPostAsync<TRequest, TResponse>(path, request, HttpContentHelper.GetMultipartForm);

        protected Task<TResponse> SendGetAsync<TRequest, TResponse>(string path, TRequest request)
            where TResponse : SlackBaseResponse
            where TRequest : class
        {
            var queryParamsDictionary = FormPropertyHelper.GetFormProperties(request).ToDictionary(p => p.PropertyName, p => p.PropertyValue);
            var url = CustomUrlHelper.CreateQueryString(path, queryParamsDictionary);
            
            return SendGetAsync<TResponse>(url);
        }
        
        protected async Task<TResponse> SendGetAsync<TResponse>(string path)
            where TResponse : SlackBaseResponse
        {
            var response = await _httpClient.GetAsync(BuildPath(path)); 
            var slackApiResponse = await ParseResponseAsync<TResponse>(response);
            
            return slackApiResponse;
        }

        protected override void DisposeObjects()
            => _httpClient?.Dispose();

        private async Task<TResponse> SendPostAsync<TRequest, TResponse>(string path, TRequest request, Func<TRequest, HttpContent> getHttpContext)
            where TResponse : SlackBaseResponse
        {
            var httpContext = getHttpContext(request);
            var response = await _httpClient.PostAsync(BuildPath(path), httpContext);
            var slackApiResponse = await ParseResponseAsync<TResponse>(response);
            
            return slackApiResponse;
        }

        private async Task<TResponse> ParseResponseAsync<TResponse>(HttpResponseMessage response)
            where TResponse : SlackBaseResponse
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var slackApiResponse = responseContent.FromJson<TResponse>(ExceptionHandlingMode.DoNotProcess);
            if (slackApiResponse?.Ok != true)
            {
                throw new SlackApiResponseException(responseContent);
            }

            return slackApiResponse;
        }

        private string BuildPath(string path)
            => $"{ObjectPath}.{path}";
    }
}