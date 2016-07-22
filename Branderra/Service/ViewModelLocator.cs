using System;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Branderra
{
	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<ItemTypeListViewModel>();
			SimpleIoc.Default.Register<ItemBrandListViewModel>();
			SimpleIoc.Default.Register<ItemCategoryListViewModel>();
			SimpleIoc.Default.Register<LoginExistingViewModel>();
			SimpleIoc.Default.Register<MainStartViewModel>();
			SimpleIoc.Default.Register<RegisterViewModel>();
			SimpleIoc.Default.Register<UserListViewModel>();
			SimpleIoc.Default.Register<SearchBarViewModel>();
			SimpleIoc.Default.Register<UserProfileViewModel>();
			SimpleIoc.Default.Register<PublishPostViewModel>();
			SimpleIoc.Default.Register<ProfileFeedNewsViewModel>();
			SimpleIoc.Default.Register<INavigationService>(() => App.NavigationService);
			SimpleIoc.Default.Register<IServerAPIProvider, BranderraServerAPIProvider>();
			SimpleIoc.Default.Register<IDatabase, BranderraDatabase>();		
		}

		/// <summary>
		/// Gets the ViewModel property.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
			"CA1822:MarkMembersAsStatic",
			Justification = "This non-static member is needed for data binding purposes.")]
		public TViewModel GetViewModel<TViewModel>()
		{
			return ServiceLocator.Current.GetInstance<TViewModel>();
		}
	}
}

