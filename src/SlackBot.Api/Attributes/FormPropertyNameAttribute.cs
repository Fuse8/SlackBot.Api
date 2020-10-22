using System;

namespace SlackBot.Api.Attributes
{
	/// <summary>
	///     Specifies the property name that is present in the form data when serializing
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	internal sealed class FormPropertyNameAttribute : Attribute
	{
		/// <summary>
		///     Initializes a new instance of <see cref="FormPropertyNameAttribute" /> with the specified property name.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		public FormPropertyNameAttribute(string name)
		{
			Name = name;
		}

		/// <summary>
		///     The name of the property.
		/// </summary>
		public string Name { get; }
	}
}