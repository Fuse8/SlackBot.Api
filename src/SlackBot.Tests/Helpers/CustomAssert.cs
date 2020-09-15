using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace SlackBot.Tests.Helpers
{
	internal class CustomAssert
	{
		public static void AreJsonEquals(string expectedJson, string actualJson)
		{
			var requestObject = JObject.Parse(actualJson);
			var expectedJObject = JObject.Parse(expectedJson);

			Assert.That(JToken.DeepEquals(requestObject, expectedJObject), "Expected Json: {0}\nActual Json: {1}", expectedJson, actualJson);
		}
	}
}