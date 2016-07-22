using System;
using Android.Graphics;
using Android.Widget;
using Branderra;
using Branderra.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (RoundedCenterImage), typeof (RoundedCenterImageRender))]
namespace Branderra.Droid
{
	public class RoundedCenterImageRender : ImageRenderer
	{
//		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
//		{
//			base.OnElementChanged (e);
//
//			var view = (RoundedCenterImage)Element;
//			var control = Control;
//
//			UpdateUi (view, control);
//		}

		protected override bool DrawChild (Canvas canvas, global::Android.Views.View child, long drawingTime)
		{
			try 
			{
				var radius = (float)(Math.Min (Width, Height) / 2);


				var rect1 = this.Element.Bounds;;
				float halfImage = radius;

				float centerX = (float)((rect1.Right + rect1.Left) / 2.0);
				float centerY = (float)((rect1.Bottom + rect1.Top) / 2.0);
				var rect = new RectF (Math.Max(0, centerX - halfImage), Math.Max(0, centerY - halfImage), 
		                      centerX + halfImage, centerY + halfImage);

				float outlineWidth = 10;

				var roundedImage = this.Element as RoundedCenterImage;
				if (roundedImage != null)
				{
					outlineWidth = roundedImage.OutlineWidth;
					radius = roundedImage.BorderRaduis;
				}
				//var strokeWidth = 10;
				//radius -= strokeWidth / 2;

				//Create path to clip
				var path = new Path ();
				//path.AddCircle (Width / 2, Height / 2, radius, Path.Direction.Ccw);
				path.AddRoundRect (rect, radius, radius, Path.Direction.Ccw);
				canvas.Save ();
				canvas.ClipPath (path);

				var result = base.DrawChild (canvas, child, drawingTime);

				canvas.Restore ();

				// Create path for circle border
				path = new Path ();
				//path.AddCircle (Width / 2, Height / 2, radius, Path.Direction.Ccw);
				path.AddRoundRect (rect, radius, radius, Path.Direction.Ccw);

				var paint = new Paint ();
				paint.AntiAlias = true;
				paint.StrokeWidth = outlineWidth;
				paint.SetStyle (Paint.Style.Stroke);
				paint.Color = global::Android.Graphics.Color.Black;

				canvas.DrawPath (path, paint);

				//Properly dispose
				paint.Dispose ();
				path.Dispose ();
				return result;
			}
			catch (Exception ex) 
			{
				throw;
				//Debug.WriteLine ("Unable to create circle image: " + ex);
			}

			//return base.DrawChild (canvas, child, drawingTime);
		}

//		void UpdateUi (RoundedCenterImage view, ImageView control)
//		{
//			
//		}

	}
}

