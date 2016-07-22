using Xamarin.Forms;

namespace Branderra
{	
	public partial class ItemTypeListView : ContentPage
	{
		public ItemTypeListView()
		{
			this.BindingContext = App.Locator.GetViewModel<ItemTypeListViewModel>();
			InitializeComponent();
		}

		protected override bool OnBackButtonPressed()
		{
			App.NavigationService.GoBack();
			return true;
		}
	}
}

