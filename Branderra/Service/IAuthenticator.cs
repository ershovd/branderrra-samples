using System;

namespace Branderra
{
	public interface IAuthenticator
	{
		void LoginToVk();
		void LoginToFacebook();
		void LoginToTwitter();
		void LoginToInstagramm();
		void PublishPost(UserFeedItemModel item);

		event EventHandler<AuthDataEventArgs> AuthCompleted;
	}
}

