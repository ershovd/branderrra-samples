using System;
using Xamarin.Forms;

namespace Branderra
{
	public class ExtendedLabel : Label
	{		
		/// <summary>
		/// The is underlined property.
		/// </summary>
		public static readonly BindableProperty IsUnderlineProperty =
			BindableProperty.Create<ExtendedLabel, bool>(p => p.IsUnderline, false);

		/// <summary>
		/// Gets or sets a value indicating whether the text in the label is underlined.
		/// </summary>
		public bool IsUnderline
		{
			get
			{
				return (bool)GetValue(IsUnderlineProperty);
			}
			set
			{
				SetValue(IsUnderlineProperty, value);
			}
		}

		/// <summary>
		/// The is underlined property.
		/// </summary>
		public static readonly BindableProperty IsStrikeThroughProperty =
			BindableProperty.Create<ExtendedLabel, bool>(p => p.IsStrikeThrough, false);

		/// <summary>
		/// Gets or sets a value indicating whether the text in the label is underlined.
		/// </summary>
		public bool IsStrikeThrough
		{
			get
			{
				return (bool)GetValue(IsStrikeThroughProperty);
			}
			set
			{
				SetValue(IsStrikeThroughProperty, value);
			}
		}

		/// <summary>
		/// The is bold property.
		/// </summary>
		public static readonly BindableProperty IsBoldProperty =
			BindableProperty.Create<ExtendedLabel, bool>(p => p.IsBold, false);

		/// <summary>
		/// Gets or sets a value indicating whether the text in the label is bold.
		/// </summary>
		public bool IsBold
		{
			get
			{
				return (bool)GetValue(IsBoldProperty);
			}
			set
			{
				SetValue(IsBoldProperty, value);
			}
		}
	}
}

