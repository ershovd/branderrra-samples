using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using XLabs.Ioc;

namespace Branderra
{
	/// <summary>
	/// Viewmodel of the start page
	/// </summary>
	public class MainStartViewModel : BranderraViewModelBase
	{
		private IAuthenticator auth;

		public MainStartViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService)
		{
			Title = "Branderra";
			auth = Resolver.Resolve<IAuthenticator>();
			auth.AuthCompleted += Auth_AuthCompleted;
		}

		public RelayCommand LoginEmailCommand
		{
			get { return new RelayCommand(NavigateToEmailSignTab); }
		}

		#region Social buttons command
		public RelayCommand FacebookLoginCommand
		{
			get { return new RelayCommand(() => NavigateWithSocialNetwork(SocialNetworkType.facebook)); }
		}

		public RelayCommand TwitterLoginCommand
		{
			get { return new RelayCommand(() => NavigateWithSocialNetwork (SocialNetworkType.twitter)); }
		}

		public RelayCommand VkontakeLoginCommand
		{
			get { return new RelayCommand(() => NavigateWithSocialNetwork (SocialNetworkType.vkontakte)); }
		}

		public RelayCommand InstagramLoginCommand
		{
			get { return new RelayCommand(() => NavigateWithSocialNetwork (SocialNetworkType.instagramm)); }
		}

		#endregion

		private void NavigateToEmailSignTab()
		{
			this.navigationService.NavigateTo(App.EmailSignTabView);
		}

		void Auth_AuthCompleted (object sender, AuthDataEventArgs e)
		{
			if (e.IsSuccess)
			{
				this.navigationService.NavigateTo (App.MainTabView);
			}
			else
			{
				
				// todo: show error
			}
		}

		private void NavigateWithSocialNetwork(SocialNetworkType socNetwork)
		{
			switch (socNetwork)
			{
			case SocialNetworkType.facebook:
				auth.LoginToFacebook ();
				break;
			case SocialNetworkType.instagramm:
				auth.LoginToInstagramm ();
				break;
			case SocialNetworkType.twitter:
				auth.LoginToTwitter ();
				break;
			case SocialNetworkType.vkontakte:
				auth.LoginToVk ();
				break;
			default:
				throw new ArgumentOutOfRangeException (nameof (socNetwork));
			}
		}
	}
}
