using Microsoft.Extensions.Configuration;

namespace SlackBot.Samples.Extensions
{
	internal static class ConfigurationExtensions
	{
		public static TSettings GetSection<TSettings>(this IConfiguration configuration, string sectionName)
			where TSettings : class, new()
		{
			var settings = new TSettings();
			configuration.GetSection(sectionName).Bind(settings);

			return settings;
		}
	}
}