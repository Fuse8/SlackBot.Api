using System.Collections.Generic;
using System.Reflection;

namespace SlackBot.Api.Helpers
{
    public static class PropertyInfoHelper
    {
        public static IEnumerable<PropertyInfo> GetPublicProperties<T>()
            => typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    }
}