﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.TeamProfile.Get.Request
{
	public class TeamProfileRequest
	{
		public TeamProfileRequest()
		{
		}

		public TeamProfileRequest(TeamFieldVisibilityType visibility)
		{
			Visibility = visibility;
		}

		/// <summary>
		/// Filter by visibility.
		/// </summary>
		/// <example>all</example>
		[FormPropertyName("visibility")]
		public TeamFieldVisibilityType Visibility { get; set; }
	}
}