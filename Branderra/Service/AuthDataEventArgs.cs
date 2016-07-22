using System;

namespace Branderra
{

	public class AuthDataEventArgs : EventArgs
	{
		public AuthDataEventArgs (bool isSuccess, Exception error, SocialNetworkType loggedNetwork)
		{
			IsSuccess = isSuccess;
			Error = error;
			LoggedNetwork = loggedNetwork;
		}

		public bool IsSuccess { get; set; }
		public Exception Error { get; set; }
		public SocialNetworkType LoggedNetwork { get; set; }
	}
}
