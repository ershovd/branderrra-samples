using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Branderra
{
	public partial class MainTabView : TabbedPage
	{
		public MainTabView()
		{
			Title = "Branderra";

			NavigationPage.SetHasBackButton (this, false);
			//NavigationPage.SetBackButtonTitle(this, "Назад");

			this.Children.Add(new UserProfileView());
			this.Children.Add(new ItemCategoryListView());
			this.Children.Add(new UsersListView());

			this.ToolbarItems.Add(new ToolbarItem(){
				Text = "Add",
				Icon = "plus24.png",
				Order = ToolbarItemOrder.Primary,
				Command = new Command( () => App.NavigationService.NavigateTo(App.PublishPostView))   //Navigation.PushAsync(new PublishPostView()))
			});
			this.ToolbarItems.Add(new ToolbarItem(){
				Text = "Search",
				Icon = "tool.png",
				Order = ToolbarItemOrder.Primary,
				Command = new Command(() => App.NavigationService.NavigateTo(App.SearchBarView)) //Navigation.PushAsync(new SearchBarView()))	
			});

			InitializeComponent();
		}

		protected override bool OnBackButtonPressed ()
		{
			return true;
			//return base.OnBackButtonPressed ();
		}
	}
}

