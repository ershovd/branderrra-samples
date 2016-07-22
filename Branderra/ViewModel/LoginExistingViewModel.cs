using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branderra
{
	public class LoginExistingViewModel :  BranderraViewModelBase	
	{
		public LoginExistingViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService)
		{
			Icon = "signin.png";
			Title = "Войти";
		}
				
		private string loginText;
		public string LoginText {
			get { return loginText;	}
			set 
			{
				if (loginText != value)
				{
					loginText = value;	
					RaisePropertyChanged();
				}

			}
		}

		string passwordText;
		public string PasswordText {
			get { return passwordText; }
			set 
			{
				if (passwordText != value)
				{
					passwordText = value;
					RaisePropertyChanged();
				}
			}
		}

		public RelayCommand LoginCommand
		{
			get { return new RelayCommand(LoginWithCredetials); }
		}

		private void LoginWithCredetials()
		{
			// TODO: use to login\password

			// TODO: change root
			navigationService.NavigateTo(App.MainTabView);
			//NavigationHelper.NavigateToSession<EmailSignTabView, MainTabView>(this, this.Navigation);
		}
	}
}
