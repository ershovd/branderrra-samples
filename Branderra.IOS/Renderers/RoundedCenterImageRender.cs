using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Branderra;
using Branderra.IOS;
using System.ComponentModel;

[assembly: ExportRenderer (typeof (RoundedCenterImage), typeof (RoundedCenterImageRender))]
namespace Branderra.IOS
{
	public class RoundedCenterImageRender : ImageRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement != null || Element == null)
				return;

			CreateRoundedImage();

		}

		private void CreateRoundedImage()
		{
			var radius = (float)(Math.Min (Element.Width, Element.Height) / 2);


//			var rect1 = this.Element.Bounds;
//
//			float halfImage = radius;
//
//			float centerX = (float)((rect1.Right + rect1.Left) / 2.0);
//			float centerY = (float)((rect1.Bottom + rect1.Top) / 2.0);


//			var rect = new RectF (Math.Max(0, centerX - halfImage), Math.Max(0, centerY - halfImage), 
//				centerX + halfImage, centerY + halfImage);

			float outlineWidth = 10;

			var roundedImage = this.Element as RoundedCenterImage;
			if (roundedImage != null)
			{
				outlineWidth = roundedImage.OutlineWidth;
				radius = roundedImage.BorderRaduis;
			}


			Control.Layer.CornerRadius = (float)(radius);
			Control.Layer.MasksToBounds = false;
			Control.Layer.BorderColor = Color.Black.ToCGColor();
			Control.Layer.BorderWidth = outlineWidth;
			Control.ClipsToBounds = true;
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
				e.PropertyName == VisualElement.WidthProperty.PropertyName)
			{
				CreateRoundedImage();
			}
		}
	}
}

