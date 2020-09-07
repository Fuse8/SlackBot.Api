using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackBot.Api.Helpers;

namespace SlackBot.Api.JsonConverters
{
	public class SubclassConverter<T> : JsonConverter<T>
		where T : class
	{
		private readonly Type _convertSubtypesOfType;
		protected readonly Type[] Subtypes;

		public SubclassConverter()
		{
			_convertSubtypesOfType = typeof(T);

			Subtypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(domainAssembly => domainAssembly.GetTypes(), (domainAssembly, assemblyType) => assemblyType)
				.Where(t => _convertSubtypesOfType.IsAssignableFrom(t) && t != _convertSubtypesOfType && !t.IsAbstract)
				.ToArray();
		}

		public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.StartObject)
				return existingValue;
			var obj = JObject.Load(reader);
			objectType = GetSubtypeToConvertTo(obj);

			existingValue = (T) Activator.CreateInstance(objectType);
			serializer.Populate(obj.CreateReader(), existingValue);

			return existingValue;
		}
		
		public override bool CanRead => true;
		public override bool CanWrite => false;

		protected virtual Type GetSubtypeToConvertTo(JObject jObject)
		{
			var jsonProperties = jObject.Properties().Select(jProp => jProp.Name.ToLowerInvariant()).ToArray();

			foreach (var subtype in Subtypes)
			{
				if (JsonHasPropertiesFromType(subtype, jsonProperties))
					return subtype;
			}
			return _convertSubtypesOfType;
		}

		private bool JsonHasPropertiesFromType(Type t, string[] jsonProperties)
		{
			var typeProperties = t.GetProperties().Select(prop => prop.GetJsonPropertyName()).ToArray();
			return jsonProperties.All(p => typeProperties.Contains(p));
		}
	}
}