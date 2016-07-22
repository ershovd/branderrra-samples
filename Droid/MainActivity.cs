using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace Branderra.Droid
{
	[Activity(Label = "Branderra", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		ScreenOrientation = ScreenOrientation.Portrait,  Theme = "@android:style/Theme.Holo.Light")]
	public class MainActivity : XLabs.Forms.XFormsApplicationDroid //global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			if(!Resolver.IsSet) SetIoc();

			LoadApplication(new App());
		}

		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();
			resolverContainer.Register<IDevice, AndroidDevice>();
			resolverContainer.RegisterSingle<IAuthenticator, AndroidAuthenticator>();
			Resolver.SetResolver(resolverContainer.GetResolver());
		}



	}
}

