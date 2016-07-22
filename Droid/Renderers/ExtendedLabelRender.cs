using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using Branderra;
using Branderra.Droid;

[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRender))]
namespace Branderra.Droid
{	
	public class ExtendedLabelRender : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			var view = (ExtendedLabel)Element;
			var control = Control;

			UpdateUi(view, control);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			var view = (ExtendedLabel)Element;

			if (e.PropertyName == ExtendedLabel.IsBoldProperty.PropertyName)
			{
				Control.PaintFlags = view.IsBold ? Control.PaintFlags | PaintFlags.FakeBoldText : Control.PaintFlags &= ~PaintFlags.FakeBoldText;
			}

			if (e.PropertyName == ExtendedLabel.IsUnderlineProperty.PropertyName)
			{
				Control.PaintFlags = view.IsUnderline ? Control.PaintFlags | PaintFlags.UnderlineText : Control.PaintFlags &= ~PaintFlags.UnderlineText;
			}

			if (e.PropertyName == ExtendedLabel.IsStrikeThroughProperty.PropertyName)
			{
				Control.PaintFlags = view.IsStrikeThrough ? Control.PaintFlags | PaintFlags.StrikeThruText : Control.PaintFlags &= ~PaintFlags.StrikeThruText;
			}
		}

		static void UpdateUi(ExtendedLabel view, TextView control)
		{
			if (view.FontSize > 0)
			{
				control.TextSize = (float)view.FontSize;
			}

			if (view.IsBold)
			{
				control.PaintFlags = control.PaintFlags | PaintFlags.FakeBoldText;
			}

			if (view.IsUnderline)
			{
				control.PaintFlags = control.PaintFlags | PaintFlags.UnderlineText;
			}

			if (view.IsStrikeThrough)
			{
				control.PaintFlags = control.PaintFlags | PaintFlags.StrikeThruText;
			}
		}
	}
}

