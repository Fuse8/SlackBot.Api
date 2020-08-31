using System;
using System.Net.Http;

namespace SlackBot.Api
{
    public class SlackApiClient : IDisposable
    {
        private bool _disposed;

        private readonly HttpClient _httpClient;

        public SlackApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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