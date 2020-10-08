using System.Collections.Generic;

namespace SlackBot.Api.Extensions
{
	internal static class ListExtensions 
	{
		public static void AddRangeIfNotNull<T>(this List<T> list, IEnumerable<T> items)
		{
			if (list != null && items != null)
			{
				list.AddRange(items);
			}
		}
	}
}