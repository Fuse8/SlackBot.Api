using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SlackBot.Api.Extensions;

namespace SlackBot.Tests.Helpers
{
	internal class CustomAssert
	{
		public static void AreJsonEquals(object model, string expectedJson)
		{
			var actualJson = model.ToJson();
			AreJsonEquals(expectedJson, actualJson);
		}
		
		public static void AreJsonEquals(string expectedJson, string actualJson)
		{
			var requestObject = JObject.Parse(actualJson);
			var expectedJObject = JObject.Parse(expectedJson);

			Assert.That(JToken.DeepEquals(requestObject, expectedJObject), "Expected Json: {0}\nActual Json: {1}", expectedJson, actualJson);
		}
	}
}