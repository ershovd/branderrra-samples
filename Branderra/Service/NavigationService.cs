using System;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace Branderra
{
	public class NavigationService : INavigationService
	{
		private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
		private NavigationPage _navigation;

		public string CurrentPageKey
		{
			get
			{
				lock (_pagesByKey)
				{
					if (_navigation.CurrentPage == null)
					{
						return null;
					}

					var pageType = _navigation.CurrentPage.GetType();

					return _pagesByKey.ContainsValue(pageType)
						? _pagesByKey.First(p => p.Value == pageType).Key
							: null;
				}
			}
		}

		public void GoBack()
		{
			_navigation.PopAsync();
		}

		public void NavigateTo(string pageKey)
		{
			NavigateTo(pageKey, null);
		}

		public void NavigateAndReplaceRoot(string pageKey, object parameter)
		{
			lock (_pagesByKey) 
			{
				if (_pagesByKey.ContainsKey (pageKey)) 
				{
					Page page = CreatePageWithConstructor (pageKey, parameter);

					_navigation.PopToRootAsync (false);
					_navigation = new NavigationPage (page);
					//_navigation.PushAsync (page);
				} else {
					throw new ArgumentException (string.Format ("No such page: {0}. Did you forget to call NavigationService.Configure?", pageKey), "pageKey");
				}
			}
		}

		public void NavigateTo(string pageKey, object parameter)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(pageKey)) {
					Page page = CreatePageWithConstructor (pageKey, parameter);;
					_navigation.PushAsync (page);
				} else
				{
					throw new ArgumentException(string.Format("No such page: {0}. Did you forget to call NavigationService.Configure?",	pageKey), "pageKey");
				}
			}
		}

		private Page CreatePageWithConstructor (string pageKey, object parameter)
		{
			var type = _pagesByKey [pageKey];
			ConstructorInfo constructor;
			object [] parameters;

			if (parameter == null) {
				constructor = type.GetTypeInfo ()
					.DeclaredConstructors
					.FirstOrDefault (c => !c.GetParameters ().Any ());

				parameters = new object []
				{
				};
			}
			else 
			{
				constructor = type.GetTypeInfo ().DeclaredConstructors
					.FirstOrDefault (
						c => {
							var p = c.GetParameters ();
							return p.Count () == 1
								&& p [0].ParameterType == parameter.GetType ();
						});

				parameters = new []
				{
							parameter
						};
			}

			if (constructor == null) 
			{
				throw new InvalidOperationException ("No suitable constructor found for page " + pageKey);
			}

			return constructor.Invoke (parameters) as Page;
		}

		public void Configure(string pageKey, Type pageType)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(pageKey))
				{
					_pagesByKey[pageKey] = pageType;
				}
				else
				{
					_pagesByKey.Add(pageKey, pageType);
				}
			}
		}

		public void Initialize(NavigationPage navigation)
		{
			_navigation = navigation;
		}
	}
}

