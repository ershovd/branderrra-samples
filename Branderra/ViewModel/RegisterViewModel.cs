using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branderra
{
	public class RegisterViewModel : BranderraViewModelBase
	{
		public RegisterViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService)
		{
			Icon = "signin.png";
			Title = "Регистрация";
		}

		private string emailText;
		public string EmailText {
			get 
			{
				return emailText;
			}
			set 
			{
				if (emailText != value)
				{
					emailText = value;	
					RaisePropertyChanged();
				}
			}
		}

		private string passwordText;
		public string PasswordText {
			get 
			{
				return passwordText;
			}
			set 
			{
				if (passwordText != value)
				{					
					passwordText = value;	
					RaisePropertyChanged();
				}

			}
		}
		private string confirmPasswordText;
		public string ConfirmPasswordText {
			get 
			{
				return confirmPasswordText;
			}
			set 
			{
				if (confirmPasswordText != value)
				{
					confirmPasswordText = value;
					RaisePropertyChanged();
				}
			}
		}

		public RelayCommand RegisterCommand
		{
			get { return new RelayCommand(RegisterUser); }
		}

		private void RegisterUser()
		{
			// TODO: register with email

			navigationService.NavigateTo(App.MainTabView);
		}
	}
}
