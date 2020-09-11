using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SlackBot.Api.Enums;
using SlackBot.Api.JsonConverters;

namespace SlackBot.Api.Extensions
{
	public static class JsonExtensions
	{
		public static T FromJson<T>(
			this string obj,
			bool isCamelCase = true,
			ExceptionHandlingMode exceptionHandlingMode = ExceptionHandlingMode.Throw)
		{
			var jsonSerializerSettings = ConfigureSettings(isCamelCase);

			return Convert(obj, exceptionHandlingMode, data => JsonConvert.DeserializeObject<T>(data, jsonSerializerSettings));
		}

		public static string ToJson(
			this object obj,
			bool isCamelCase = true,
			ExceptionHandlingMode exceptionHandlingMode = ExceptionHandlingMode.Throw)
		{
			var jsonSerializerSettings = ConfigureSettings(isCamelCase);

			return Convert(obj, exceptionHandlingMode, data => JsonConvert.SerializeObject(data, jsonSerializerSettings));
		}

		private static TResult Convert<TData, TResult>(
			TData data,
			ExceptionHandlingMode exceptionHandlingMode,
			Func<TData, TResult> converter)
		{
			TResult result = default;

			try
			{
				if (data != null)
				{
					result = converter(data);
				}
			}
			catch (Exception)
			{
				if (exceptionHandlingMode == ExceptionHandlingMode.Throw)
				{
					throw;
				}
			}

			return result;
		}

		private static JsonSerializerSettings ConfigureSettings(bool isCamelCase)
		{
			var settings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
			};

			var namingStrategy = isCamelCase
				? (NamingStrategy) new CamelCaseNamingStrategy()
				: new DefaultNamingStrategy();
			
			settings.Converters.Add(new StringEnumConverter(namingStrategy));
			
			foreach (var jsonConverter in JsonConverterHelper.GetSpecificClassConverters())
			{
				settings.Converters.Add(jsonConverter);
			}
			
			settings.ContractResolver = new DefaultContractResolver {NamingStrategy = namingStrategy};

			return settings;
		}
	}
}