using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.TeamProfile.Get.Response
{
	public class TeamProfile
	{
		[JsonProperty("fields")]
		public List<TeamField> Fields { get; set; }
	}
}