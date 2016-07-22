using Xamarin.Forms;
using GalaSoft.MvvmLight.Views;

namespace Branderra
{
	public partial class MainStartView : ContentPage
	{
		public MainStartView()
		{
			this.BindingContext = App.Locator.GetViewModel<MainStartViewModel>();
			InitializeComponent();		
		}		
	}
}

