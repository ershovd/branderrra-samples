using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using GalaSoft.MvvmLight.Messaging;

namespace Branderra
{
	/// <summary>
	/// Base class for Branderra view model with service
	/// </summary>
	public class BranderraViewModelBase : ViewModelBase
	{
		protected readonly IServerAPIProvider service;
		protected INavigationService navigationService;

		public BranderraViewModelBase(IServerAPIProvider service, INavigationService navigationService)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (service == null) throw new ArgumentNullException("service");

			this.navigationService = navigationService;
			this.service = service;
		}


		public void RegisterMessage<TMessage>(Action<TMessage> act)
		{
			Messenger.Default.Register<TMessage>(this, act);
		}

		public void SendMessage<TMessage>(TMessage message)
		{
			Messenger.Default.Send<TMessage>(message);
		}


		public string Title { get; set; }

		public string Icon { get; set; }

	}
}
