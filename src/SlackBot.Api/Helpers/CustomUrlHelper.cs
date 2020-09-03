using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SlackBot.Api.Helpers
{
    public static class CustomUrlHelper
    {
        public static string BuildUrl(Uri baseUri, string path, Dictionary<string, string> queryParams = null, int port = -1)
        {
            var builder = new UriBuilder(baseUri)
            {
                Port = port
            };

            var currentPath = builder.Path;
            if (!string.IsNullOrEmpty(currentPath) && !currentPath.EndsWith("/"))
            {
                currentPath += "/";
            }
            
            builder.Path = currentPath + path;
            
            if (queryParams != null && queryParams.Any())
            {
                builder.Query = CreateQueryString(queryParams);
            }
            
            return builder.ToString();
        }

        private static string CreateQueryString(Dictionary<string, string> queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var queryParam in queryParams)
            {
                query.Add(queryParam.Key, queryParam.Value);
            }

            return query.ToString();
        }
    }
}