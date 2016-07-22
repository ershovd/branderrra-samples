using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class CommentsListView : ContentPage
	{
		public CommentsListView()
		{
			this.Title = "Комментарии";
			InitializeComponent();

			var service = SimpleIoc.Default.GetInstance<IServerAPIProvider>();

			this.commentListView.ItemsSource = service.GetCommentForFeed(Guid.Empty);
			this.commentListView.ItemTapped += CommentListView_ItemTapped;
		}

		void CommentListView_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			this.commentListView.SelectedItem = null;
			this.Navigation.PushAsync(new ProfileFeedNewsView());
		}
	}
}

