using System;
using Xamarin.Auth;
using Android.App;
using Xamarin.Forms;
using System.Xml;
using System.Net;
using System.IO;
using LinqToTwitter;
using Facebook;

namespace Branderra.Droid
{
	public class AndroidAuthenticator : IAuthenticator
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
			var auth = new OAuth2Authenticator (
				clientId: "YOUR_ID",
				// TODO: prepare and send for review
				scope: "",  //scope: "user_about_me,publish_pages,manage_pages",
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"),
				redirectUrl: new Uri ("YOUR_URL"));
			auth.AllowCancel = true;
			auth.Error += (sender, e) => 
			{
				InvokeAuthCompleted (false, e.Exception, SocialNetworkType.facebook);
			};
			auth.Completed += (sender, e) => 
			{
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

			var intent = auth.GetUI(Forms.Context);
			Forms.Context.StartActivity (intent);
		}

		// http://www.codeproject.com/Tips/852742/Simple-Twitter-client-using-Xamarin-Forms-Xamarin
		public void LoginToTwitter ()
		{
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
			};

			auth.Completed += (sender, e) => {

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

			var intent = auth.GetUI(Forms.Context);
			Forms.Context.StartActivity (intent);
		}

		// https://phpbl.ru/php/instagram-api-avtomaticheskij-posting.htmll
		public void LoginToInstagramm ()
		{
			var auth = new OAuth2Authenticator (
				clientId: "CLIENT_IDs",
				scope: "basic",
				authorizeUrl: new Uri ("https://api.instagram.com/oauth/authorize/"),
				redirectUrl: new Uri ("YOUR_URL")
			);
			auth.AllowCancel = true;
			auth.Error += (sender, e) => 
			{
				InvokeAuthCompleted (false, e.Exception, SocialNetworkType.instagramm);
			};
			auth.Completed += (sender, e) => {
				if (e.IsAuthenticated)
				{
					token = e.Account.Properties ["access_token"];
					LoggedNetwork = SocialNetworkType.instagramm;
					InvokeAuthCompleted (LoggedNetwork);
				}
			};

			var intent = auth.GetUI (Forms.Context);
			Forms.Context.StartActivity (intent);
		}

		public void LoginToVk()
		{
			var auth = new OAuth2Authenticator (
				clientId: "CLIENT_ID",
				scope: "friends,video,groups, wall",
				authorizeUrl: new Uri ("https://oauth.vk.com/authorize"),
				redirectUrl: new Uri ("https://oauth.vk.com/blank.html"));
			auth.AllowCancel = true;
			auth.Error += (sender, e) => {
				InvokeAuthCompleted (false, e.Exception, SocialNetworkType.vkontakte);
			};
			auth.Completed += (s, ee) => {
				
				if (ee.IsAuthenticated) {
					token = ee.Account.Properties ["access_token"].ToString ();
					userId = ee.Account.Properties ["user_id"].ToString ();
					LoggedNetwork = SocialNetworkType.vkontakte;
					InvokeAuthCompleted (LoggedNetwork);

				}
			};
			var intent = auth.GetUI(Forms.Context);
			Forms.Context.StartActivity (intent);
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

			var builder = new AlertDialog.Builder (Forms.Context);
			builder.SetMessage ("Пост опубликован");
			builder.SetPositiveButton ("OK", (o, e) => { });
			builder.Create().Show();
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
					ConsumerKey = "bAmgk3AypfInjjtydEerCLHvd",
					ConsumerSecret = "TIeqfBbQeprMtReXPrW2U8YCGWO8tFIt2SVVUKg3506JBzHg5k",
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

		private void PublishInVk(string text)
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

