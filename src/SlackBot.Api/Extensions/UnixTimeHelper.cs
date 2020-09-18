using System;

namespace SlackBot.Api.Extensions
{
	public static class UnixTimeHelper
	{
		public static long ToUnixTime(DateTime time)
			=> new DateTimeOffset(time).ToUnixTimeSeconds();

		public static DateTime? FromUnixToLocalDateTime(long? unixDateTime)
			=> unixDateTime != null
				? FromUnixToLocalDateTime(unixDateTime.Value)
				: (DateTime?)null;
		
		public static DateTime FromUnixToLocalDateTime(long unixDateTime)
			=> FromUnixToUtcDateTime(unixDateTime).ToLocalTime();
		
		public static DateTime? FromUnixToUtcDateTime(long? unixDateTime)
			=> unixDateTime != null
				? FromUnixToUtcDateTime(unixDateTime.Value)
				: (DateTime?)null;
		
		public static DateTime FromUnixToUtcDateTime(long unixDateTime)
			=> DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime;
	}
}