using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class RegisterView : ContentPage
	{
		public RegisterView()
		{
			this.BindingContext = App.Locator.GetViewModel<RegisterViewModel>();
			InitializeComponent();			
		}		
	}
}

