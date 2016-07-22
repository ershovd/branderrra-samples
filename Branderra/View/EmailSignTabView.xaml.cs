using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Branderra
{
	public partial class EmailSignTabView : TabbedPage
	{
		public EmailSignTabView()
		{
			this.Children.Add(new LoginExistingView());
			this.Children.Add(new RegisterView());

			InitializeComponent();
		}
	}

	/*
	public class NavigationHelper
	{
		public static void NavigateToSession<TInitial, TNewRoot>(Page rootPage, INavigation navigation) where TNewRoot : Page, new()
		{
			var existingPages = navigation.NavigationStack.ToList();
			foreach (var page in existingPages)
			{
				if (page.GetType() != typeof(TInitial))
					navigation.RemovePage(page);
			}
			ChangeRoot<TNewRoot>(rootPage);
		}

		public static void ChangeRoot<TRootPage>(Page page) where TRootPage : Page, new()
		{
			var root = page.Navigation.NavigationStack[0];
			page.Navigation.InsertPageBefore(new TRootPage(), root);
			page.Navigation.PopToRootAsync();
		}
	}
*/
}

