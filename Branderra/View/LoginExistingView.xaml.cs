using Xamarin.Forms;

namespace Branderra
{
	public partial class LoginExistingView : ContentPage
	{
		public LoginExistingView()
		{
			this.BindingContext = App.Locator.GetViewModel<LoginExistingViewModel>();
			
			InitializeComponent();
		}		
	}
}

