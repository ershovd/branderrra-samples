using System;
using Xamarin.Forms;

namespace Branderra
{
	public class RoundedCenterImage : Image
	{
		public RoundedCenterImage ()
		{
			BorderRaduis = 10;
			OutlineWidth = 2;
			Aspect = Aspect.AspectFill;
		}

		/// <summary>
		/// OutlineWidth property.
		/// </summary>
		public static readonly BindableProperty OutlineWidthProperty =
			BindableProperty.Create<RoundedCenterImage, float> (p => p.OutlineWidth, (float)0.0);

		/// <summary>
		/// Gets or sets a value indicating whether the text in the label is underlined.
		/// </summary>
		public float OutlineWidth {
			get { return (float)GetValue (OutlineWidthProperty); }
			set { SetValue (OutlineWidthProperty, value); }
		}


		/// <summary>
		/// The is BorderRaduis property.
		/// </summary>
		public static readonly BindableProperty BorderRaduisProperty = 
			BindableProperty.Create<RoundedCenterImage, float> (p => p.BorderRaduis, (float)0.0);

		/// <summary>
		/// Gets or sets a value indicating whether the text in the label is underlined.
		/// </summary>
		public float BorderRaduis 
		{
			get { return (float)GetValue (BorderRaduisProperty); }
			set { SetValue (BorderRaduisProperty, value); }
		}
	}
}

