using NUnit.Framework;
using SlackBot.Api.Extensions;
using SlackBot.Tests.Helpers;

namespace SlackBot.Tests.PostMessageTests
{
	internal class ModelsSerializationTests
	{
		[TestCaseSource(typeof(PostMessageSerializationCases), nameof(PostMessageSerializationCases.MessageCases))]
		public void MessageConvertsToCorrectJson(object model, string expectedJson) 
			=> AssertJsonIsCorrect(model, expectedJson);
		
		[TestCaseSource(typeof(PostMessageSerializationCases), nameof(PostMessageSerializationCases.BlockCases))]
		public void BlockConvertsToCorrectJson(object model, string expectedJson) 
			=> AssertJsonIsCorrect(model, expectedJson);
		
		[TestCaseSource(typeof(PostMessageSerializationCases), nameof(PostMessageSerializationCases.ElementCases))]
		public void ElementConvertsToCorrectJson(object model, string expectedJson) 
			=> AssertJsonIsCorrect(model, expectedJson);
		
	
		[TestCaseSource(typeof(PostMessageSerializationCases), nameof(PostMessageSerializationCases.MessageObjectCases))]
		public void MessageObjectConvertsToCorrectJson(object model, string expectedJson) 
			=> AssertJsonIsCorrect(model, expectedJson);

		private static void AssertJsonIsCorrect(object model, string expectedJson)
		{
			var actualJson = model.ToJson();
			CustomAssert.AreJsonEquals(expectedJson, actualJson);
		}
	}
}