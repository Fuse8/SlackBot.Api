using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using SlackBot.Api.Extensions;

namespace SlackBot.Api.Helpers
{
	internal static class HttpContentHelper
	{
		public static StringContent GetJsonStringContent<TRequest>(TRequest request)
			where TRequest : class
		{
			var json = request.ToJson();
			var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

			return stringContent;
		}

		public static FormUrlEncodedContent GetFormUrlEncodedContent<TRequest>(TRequest request)
			where TRequest : class
		{
			var dataDictionary = FormPropertyHelper.GetFormProperties(request)
				.ToDictionary(property => property.PropertyName, propertyInfo => propertyInfo.PropertyValue);
			var formUrlEncodedContent = new FormUrlEncodedContent(dataDictionary);

			return formUrlEncodedContent;
		}

		public static HttpContent GetMultipartForm<TRequest>(TRequest request)
			where TRequest : class
		{
			var multipartContent = new MultipartFormDataContent();

			var properties = PropertyInfoHelper.GetPublicProperties<TRequest>();
			foreach (var property in properties)
			{
				var propertyValue = property.GetValue(request);
				if (propertyValue != null)
				{
					var fileFormPropertyName = FormPropertyHelper.GetFormPropertyName(property);
					AddContent(propertyValue, fileFormPropertyName);
				}
			}

			return multipartContent;

			void AddContent(object propertyValue, string fileFormPropertyName)
			{
				if (propertyValue is FileStream fileStream)
				{
					multipartContent.Add(new StreamContent(fileStream), fileFormPropertyName, fileStream.Name);
				}
				else if (propertyValue is Stream || propertyValue.GetType().BaseType == typeof(Stream))
				{
					multipartContent.Add(new StreamContent((Stream)propertyValue), fileFormPropertyName, Guid.NewGuid().ToString());
				}
				else
				{
					multipartContent.Add(new StringContent(propertyValue.ToString()), fileFormPropertyName);
				}
			}
		}
	}
}