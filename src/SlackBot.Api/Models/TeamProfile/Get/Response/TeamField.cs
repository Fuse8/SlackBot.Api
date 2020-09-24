using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.TeamProfile.Get.Response
{
	public class TeamField
	{
		[JsonProperty("id")]
		public string Id { get; set; } 

		[JsonProperty("ordering")]
		public long Ordering { get; set; } 

		[JsonProperty("field_name")]
		public string FieldName { get; set; }  

		[JsonProperty("label")]
		public string Label { get; set; } 

		[JsonProperty("hint")]
		public string Hint { get; set; } 

		[JsonProperty("type")]
		public string Type { get; set; } 

		[JsonProperty("possible_values")]
		public object[] PossibleValues { get; set; } 

		[JsonProperty("options")]
		public Dictionary<string, object> Options { get; set; } 

		[JsonProperty("is_hidden")]
		public bool? IsHidden { get; set; }
	}
}