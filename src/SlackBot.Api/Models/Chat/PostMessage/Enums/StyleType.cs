namespace SlackBot.Api.Models.Chat.PostMessage.Enums
{
	public enum StyleType
	{
		/// <summary>
		/// <see cref="Primary"/> gives buttons a green outline and text, ideal for affirmation or confirmation actions.
		/// <see cref="Primary"/> should only be used for one button within a set.
		/// </summary>
		Primary,

		/// <summary>
		/// <see cref="Danger"/> gives buttons a red outline and text, and should be used when the action is destructive.
		/// Use <see cref="Danger"/> even more sparingly than <see cref="Primary"/>.
		/// </summary>
		Danger,
	}
}