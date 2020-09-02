﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SlackBot.Api.Attributes;

namespace SlackBot.Api.Helpers
{
    public static class FormPropertyHelper
    {
        public static IEnumerable<(string PropertyName, string PropertyValue)> GetFormProperties<T>(T model)
            => PropertyInfoHelper.GetPublicProperties<T>()
                .Select(
                    propertyInfo =>
                    (
                        PropertyName: GetFormPropertyName(propertyInfo),
                        PropertyValue: propertyInfo.GetValue(model)?.ToString()
                    ))
                .Where(p => p.PropertyValue != null);

        public static string GetFormPropertyName<T>(string propertyName)
        {
            var propertyInfo = PropertyInfoHelper.GetPublicProperties<T>().FirstOrDefault(p => p.Name == propertyName);
            return GetFormPropertyName(propertyInfo);
        }

        private static string GetFormPropertyName(PropertyInfo propertyInfo)
            => propertyInfo.GetCustomAttribute<FormPropertyNameAttribute>()?.Name ?? propertyInfo.Name;
    }
}