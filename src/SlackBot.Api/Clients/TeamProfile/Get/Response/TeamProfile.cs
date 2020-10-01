using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients.Get.Response
{
	public class TeamProfile
	{
		[JsonProperty("fields")]
		public List<TeamField> Fields { get; set; }
	}
}