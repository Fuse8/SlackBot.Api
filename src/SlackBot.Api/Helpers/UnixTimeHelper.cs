using System;

namespace SlackBot.Api.Helpers
{
	public static class UnixTimeHelper
	{
		/// <summary>
		/// The number of ticks per microsecond.
		/// </summary>
		private const int TicksPerMicrosecond = 10;
		
		public static long ToUnixTime(DateTime time)
			=> new DateTimeOffset(time).ToUnixTimeSeconds();

		public static DateTime? FromUnixToLocalDateTime(string unixDateTime)
			=> FromUnixToDateTime(unixDateTime, FromUnixToLocalDateTime);

		public static DateTime? FromUnixToLocalDateTime(long? unixDateTime)
			=> unixDateTime != null
				? FromUnixToLocalDateTime(unixDateTime.Value)
				: (DateTime?)null;
		
		public static DateTime FromUnixToLocalDateTime(long unixDateTime)
			=> FromUnixToUtcDateTime(unixDateTime).ToLocalTime();
		
		public static DateTime? FromUnixToUtcDateTime(string unixDateTime)
			=> FromUnixToDateTime(unixDateTime, FromUnixToUtcDateTime);
		
		public static DateTime? FromUnixToUtcDateTime(long? unixDateTime)
			=> unixDateTime != null
				? FromUnixToUtcDateTime(unixDateTime.Value)
				: (DateTime?)null;
		
		public static DateTime FromUnixToUtcDateTime(long unixDateTime)
			=> DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime;
		
		private static DateTime? FromUnixToDateTime(string unixDateTime, Func<long, DateTime> timeZoneDependentParserFunc)
		{
			DateTime? result = null;

			if (!string.IsNullOrWhiteSpace(unixDateTime))
			{
				var unixParts = unixDateTime.Split('.');
				var unixSeconds = long.Parse(unixParts[0]);
				result = timeZoneDependentParserFunc(unixSeconds);

				if (unixParts.Length == 2)
				{
					var unixMicrosecondsStr = unixParts[1];
					if (!string.IsNullOrWhiteSpace(unixMicrosecondsStr))
					{
						var unixMicroseconds = long.Parse(unixMicrosecondsStr);
						result = result.Value.AddTicks(unixMicroseconds * TicksPerMicrosecond);
					}
				}
			}

			return result;
		}
	}
}