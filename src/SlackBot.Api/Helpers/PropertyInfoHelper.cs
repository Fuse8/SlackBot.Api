using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace SlackBot.Api.Helpers
{
    internal static class PropertyInfoHelper
    {
        public static IEnumerable<PropertyInfo> GetPublicProperties<T>()
            => typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

        public static string GetJsonPropertyName(this PropertyInfo prop) 
            => prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? prop.Name.ToLowerInvariant();
    }
}