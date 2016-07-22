using System;
using Xamarin.Forms;
using System.Xml;
using System.Net;
using System.IO;
using Xamarin.Auth;
using Branderra;
using UIKit;
using Facebook;
using LinqToTwitter;

namespace Branderra.IOS
{
	public class iOSAuthenticator : IAuthenticator
	{
		private string token;
		private string userId;
		private SocialNetworkType LoggedNetwork;

		private ulong tweetUserId;
		private string tweetScreenName;

		public event EventHandler<AuthDataEventArgs> AuthCompleted;

		private void InvokeAuthCompleted(bool isSucess, Exception ex, SocialNetworkType socNetwork)
		{
			var handler = AuthCompleted;
			if (handler != null)
			{
				handler (this, new AuthDataEventArgs (isSucess, ex, socNetwork));
			}
		}

		private void InvokeAuthCompleted(SocialNetworkType socNetwork)
		{
			InvokeAuthCompleted (true, null, socNetwork);
		}

		// https://components.xamarin.com/gettingstarted/facebookandroidd
		public void LoginToFacebook ()
		{
			var root = UIApplication.SharedApplication.KeyWindow;

			var auth = new OAuth2Authenticator (
				clientId: "CLIENT_ID",
				// TODO: prepare and send for review
				scope: "",  //scope: "user_about_me,publish_pages,manage_pages",
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri ("http://brandera.azurewebsites.net/"));
			auth.AllowCancel = true;
			auth.Error += (sender, e) => 
			{
				InvokeAuthCompleted (false, e.Exception, SocialNetworkType.facebook);
			};
			auth.Completed += (sender, e) => 
			{
				root.RootViewController.DismissViewController(true, null);
				if (e.IsAuthenticated)
				{
					
					token = e.Account.Properties ["access_token"].ToString ();
					LoggedNetwork = SocialNetworkType.facebook;
					InvokeAuthCompleted (LoggedNetwork);
				}
				else
				{
					
				}
			};

			var intent = auth.GetUI();
			root.RootViewController.PresentViewController(intent, true, null);
		}

		// http://www.codeproject.com/Tips/852742/Simple-Twitter-client-using-Xamarin-Forms-Xamarin
		public void LoginToTwitter ()
		{
			var root = UIApplication.SharedApplication.KeyWindow;
			var controller = root.RootViewController;

			var auth = new OAuth1Authenticator (
				consumerKey: "KEY",
				consumerSecret: "SECRET",
				requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
				authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
				accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
				callbackUrl: new Uri("YOUR_URL")
			);
			auth.AllowCancel = true;
			auth.Error += (sender, e) => {
				InvokeAuthCompleted (false, e.Exception, SocialNetworkType.twitter);
				root.RootViewController.DismissViewController(true, null);
			};

			auth.Completed += (sender, e) => {

				root.RootViewController.DismissViewController(true, null);

				if (e.IsAuthenticated)
				{
					// success
					token = e.Account.Properties["oauth_token"];
					userId = e.Account.Properties["oauth_token_secret"];
					tweetUserId = ulong.Parse(e.Account.Properties["user_id"]);
					tweetScreenName = e.Account.Properties["screen_name"];
					LoggedNetwork = SocialNetworkType.twitter;
					InvokeAuthCompleted (LoggedNetwork);					
				}				
			};

			var intent = auth.GetUI();
			controller.PresentViewController(intent, true, null);
		}

		// https://phpbl.ru/php/instagram-api-avtomaticheskij-posting.htmll
		public void LoginToInstagramm ()
		{
			var root = UIApplication.SharedApplication.KeyWindow;
			var auth = new OAuth2Authenticator (
				clientId: "CLIENT_ID",
				scope: "basic",
				authorizeUrl: new Uri ("https://api.instagram.com/oauth/authorize/"),
				redirectUrl: new Uri ("YOUR_URL")
			);
			auth.AllowCancel = true;
			auth.Error += (sender, e) => 
			{
				InvokeAuthCompleted (false, e.Exception, SocialNetworkType.instagramm);
				root.RootViewController.DismissViewController(true, null);
			};
			auth.Completed += (sender, e) => {
				root.RootViewController.DismissViewController(true, null);
				if (e.IsAuthenticated)
				{
					token = e.Account.Properties ["access_token"];
					LoggedNetwork = SocialNetworkType.instagramm;
					InvokeAuthCompleted (LoggedNetwork);
				}
			};

			var intent = auth.GetUI ();
			root.RootViewController.PresentViewController(intent, true, null);
		}

		public void LoginToVk()
		{
			var root = UIApplication.SharedApplication.KeyWindow;

			var auth = new OAuth2Authenticator (
				clientId: "CLIENT_ID",
				scope: "friends,video,groups, wall",
				authorizeUrl: new Uri ("https://oauth.vk.com/authorize"),
				redirectUrl: new Uri ("https://oauth.vk.com/blank.html"));
			auth.AllowCancel = true;
			auth.Error += (sender, e) => 
			{
				InvokeAuthCompleted (false, e.Exception, SocialNetworkType.vkontakte);
				root.RootViewController.DismissViewController(true, null);
			};
			auth.Completed += (s, ee) => {

				root.RootViewController.DismissViewController(true, null);

				if (ee.IsAuthenticated) 
				{
					token = ee.Account.Properties ["access_token"].ToString ();
					userId = ee.Account.Properties ["user_id"].ToString ();
					LoggedNetwork = SocialNetworkType.vkontakte;
					InvokeAuthCompleted (LoggedNetwork);
				}
			};
			var intent = auth.GetUI();
			root.RootViewController.PresentViewController(intent, true, null);
		}

		public void PublishPost(UserFeedItemModel item)
		{	
			var text = item.PostDescription;

			switch (LoggedNetwork) 
			{
			case SocialNetworkType.facebook:
				//PublishInFacebook (text);
				break;
			case SocialNetworkType.instagramm:
				break;
			case SocialNetworkType.twitter:
				PublishInTwitter (text);
				break;
			case SocialNetworkType.vkontakte:
				PublishInVk (text);
				break;
			default:
				throw new ArgumentOutOfRangeException ();
			}

			UIAlertView view = new UIAlertView("Branderra", "Published", null, "Ok");
			view.WillDismiss += (sender, e) => {  };
			view.Show();
		}

		private void PublishInFacebook (string text)
		{
			FacebookClient fb = new FacebookClient (token);
			string myMessage = text;

			fb.PostTaskAsync ("me/feed", new { message = myMessage }).ContinueWith (t => {
				if (!t.IsFaulted) {
					string message = "Great, your message has been posted to you wall!";
					Console.WriteLine (message);
				}
			});
		}

		private async void PublishInTwitter (string text)
		{
			var auth = new XAuthAuthorizer
			{
				CredentialStore = new InMemoryCredentialStore
				{
					ConsumerKey = "KEY",
					ConsumerSecret = "SECRET",
					// todo: fix auth
					OAuthToken = token,
					OAuthTokenSecret = userId,
					ScreenName = tweetScreenName,
					UserID = tweetUserId
				}
			};
			//auth.AuthorizeAsync ();

			var tweetContext = new TwitterContext (auth);

			var result = await tweetContext.TweetAsync (text);

			if (result != null) 
			{
				var tt = result.Count;
			}
		}


		public void PublishInVk(string text)
		{				
			XmlDocument xmlDocument = new XmlDocument();

			string requeststring = "https://api.vk.com/method/wall.post.xml?&access_token=" + token + "&owner_id=" + userId
			                        + "&message=" + text;
			WebRequest webRequest = WebRequest.Create(requeststring);			
			WebResponse webResponse = webRequest.GetResponse();
			Stream stream = webResponse.GetResponseStream();
			xmlDocument.Load(stream);

		}
	}
}

