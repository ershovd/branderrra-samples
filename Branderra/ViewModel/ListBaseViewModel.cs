using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Branderra
{
	/// <summary>
	/// Base class for view model with List of elements
	/// </summary>
	public abstract class ListBaseViewModel<TViewModel> : BranderraViewModelBase where TViewModel : class
	{
		protected ListBaseViewModel(IServerAPIProvider service, INavigationService navigationService, bool isSkipInit = false) : base(service, navigationService)
		{
			if (isSkipInit)
				return;

			Init();
		}	     

		protected void Init()
		{
			if (Items != null) return;

			// TODO: support for NotifyTaskCompletion

			Items = new ObservableCollection<TViewModel>(GetItems());
		}

		public abstract IEnumerable<TViewModel> GetItems();
		
		ObservableCollection<TViewModel> items;
		public ObservableCollection<TViewModel> Items {
			get 
			{
				return items;
			}
			protected set 
			{
				if (items != value)
				{
					items = value;
					RaisePropertyChanged();
				}
			}
		}

		TViewModel itemSelected;
		public TViewModel ItemSelected {
			get 
			{
				return itemSelected;
			}
			set 
			{
				if (itemSelected != value)
				{
					itemSelected = value;
					Navigate();
					RaisePropertyChanged();
					itemSelected = null;
				}
			}
		}

		public abstract void Navigate();
	}
}
