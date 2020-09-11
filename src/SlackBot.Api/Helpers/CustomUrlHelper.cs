using System.Collections.Generic;
using System.Web;

namespace SlackBot.Api.Helpers
{
    public static class CustomUrlHelper
    {
        public static string CreateQueryString(string path, Dictionary<string, string> queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var queryParam in queryParams)
            {
                query.Add(queryParam.Key, queryParam.Value);
            }

            return $"{path}?{query}";
        }
    }
}