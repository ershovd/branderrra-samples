using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Branderra
{
	public class App : Application
	{
		public static string ItemTypeListView = "ItemTypeListView";
		public static string MainStartView = "MainStartView";
		public static string EmailSignTabView = "EmailSignTabView";
		public static string MainTabView = "MainTabView";
		public static string CommentsListView = "CommentsListView";
		public static string ItemBrandListView = "ItemBrandListView";
		public static string ItemCategoryListView = "ItemCategoryListView";
		public static string LoginExistingView = "LoginExistingView";
		public static string ProfileFeedNewsView = "ProfileFeedNewsView";
		public static string PublishPostView = "PublishPostView";
		public static string RegisterView = "RegisterView";
		public static string SearchBarView = "SearchBarView";
		public static string UserProfileView = "UserProfileView";
		public static string UsersListView = "UsersListView";


		public App()
		{			
			NavigationPage navPage = new NavigationPage(new MainStartView());
			navPage.BarBackgroundColor = Constants.ColorBlue;
			navPage.BarTextColor = Constants.ColorWhite;
			RegisteNavigation(navPage);
			MainPage = navPage;
		}


		static void RegisteNavigation(NavigationPage navPage)
		{		
			//_navigationService = new NavigationService();

			_navigationService.Configure(ItemTypeListView, typeof(ItemTypeListView));
			_navigationService.Configure(MainStartView, typeof(MainStartView));
			_navigationService.Configure(EmailSignTabView, typeof(EmailSignTabView));
			_navigationService.Configure(MainTabView, typeof(MainTabView));
			_navigationService.Configure(CommentsListView, typeof(CommentsListView));
			_navigationService.Configure(ItemBrandListView, typeof(ItemBrandListView));
			_navigationService.Configure(ItemCategoryListView, typeof(ItemCategoryListView));
			_navigationService.Configure(LoginExistingView, typeof(LoginExistingView));
			_navigationService.Configure(ProfileFeedNewsView, typeof(ProfileFeedNewsView));
			_navigationService.Configure(PublishPostView, typeof(PublishPostView));
			_navigationService.Configure(RegisterView, typeof(RegisterView));
			_navigationService.Configure(SearchBarView, typeof(SearchBarView));
			_navigationService.Configure(UserProfileView, typeof(UserProfileView));
			_navigationService.Configure(UsersListView, typeof(UsersListView));



			_navigationService.Initialize(navPage);
		}

		private static NavigationService _navigationService;

		public static INavigationService NavigationService
		{
			get
			{
				return _navigationService ?? (_navigationService = new NavigationService());
			}
		}

		private static ViewModelLocator _locator;

		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

