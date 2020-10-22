using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SlackBot.Api.Attributes;

namespace SlackBot.Api.Helpers
{
	internal static class FormPropertyHelper
	{
		public static IEnumerable<(string PropertyName, string PropertyValue)> GetFormProperties<T>(T model)
		{
			return PropertyInfoHelper.GetPublicProperties<T>()
				.Select(
					propertyInfo =>
					(
						PropertyName: GetFormPropertyName(propertyInfo),
						PropertyValue: GetValue(propertyInfo)
					))
				.Where(p => p.PropertyValue != null);

			string GetValue(PropertyInfo info)
			{
				string stringValue = null;
				
				var propertyValue = info.GetValue(model);
				if (propertyValue != null)
				{
					stringValue = propertyValue.ToString();
					if (propertyValue is Enum)
					{
						stringValue = stringValue.ToLower();
					}
				}
				return stringValue;
			}
		}

		public static string GetFormPropertyName(PropertyInfo propertyInfo)
			=> propertyInfo.GetCustomAttribute<FormPropertyNameAttribute>()?.Name ?? propertyInfo.Name;
	}
}