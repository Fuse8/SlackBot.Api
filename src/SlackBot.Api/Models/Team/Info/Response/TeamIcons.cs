using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.Team.Info.Response
{
	public class TeamIcons
	{
		[JsonProperty("image_34")]
		public Uri Image34Url { get; set; }

		[JsonProperty("image_44")]
		public Uri Image44Url { get; set; }

		[JsonProperty("image_68")]
		public Uri Image68Url { get; set; }

		[JsonProperty("image_88")]
		public Uri Image88Url { get; set; }

		[JsonProperty("image_102")]
		public Uri Image102Url { get; set; }

		[JsonProperty("image_132")]
		public Uri Image132Url { get; set; }

		[JsonProperty("image_230")]
		public Uri Image230Url { get; set; }

		[JsonProperty("image_original")]
		public Uri ImageOriginalUrl { get; set; }

		[JsonProperty("image_default")]
		public bool? ImageDefault { get; set; }
	}
}