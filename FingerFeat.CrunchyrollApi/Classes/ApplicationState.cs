using System.Collections.Generic;

namespace FingerFeat.CrunchyrollApi.Classes
{
	using FingerFeat.CrunchyrollApi.Classes.Models;

	public class ApplicationState
	{
		private string _auth;
		private Session _session;
		private User _loggedInUser;
		private Dictionary<string, string> appStateStore;

		public ApplicationState()
		{
			appStateStore = new Dictionary<string, string>();
		}

		public Session GetSession()
		{
			if (!appStateStore.ContainsKey("session/id"))
			{
				if (appStateStore.Count > 0)
				{
					var localSession = new Session();
					localSession.SetId(appStateStore["session/id"]);
					localSession.SetCountryCode(appStateStore["session/cc"]);
					var localOptional1 = GetAuth();
					if (localOptional1 != null)
						localSession.SetAuth(localOptional1);
					var localOptional2 = GetLoggedInUser();
					if (localOptional2 != null)
						localSession.SetUser(localOptional2);
					_session = localSession;
					return localSession;
				}
			}
			if(_session==null)
				_session = new Session();
			return _session;
		}

		public void SetSession(Session session)
		{
			if (!appStateStore.ContainsKey("session/id"))
				appStateStore.Add("session/id", session.GetId());

			if (!appStateStore.ContainsKey("session/cc"))
				appStateStore.Add("session/cc", session.GetCountryCode());

			var localOptional1 = session.GetAuth();
			if (localOptional1 != null)
				SetAuth(localOptional1);

			var localOptional2 = session.GetUser();
			if (localOptional2 != null)
				SetLoggedInUser(localOptional2);

			_session = session;
		}


		public User GetLoggedInUser()
		{
			return _loggedInUser;
		}

		public void SetLoggedInUser(User user)
		{
			_loggedInUser = user;
		}

		public string GetAuth()
		{
			return _auth;
		}
		public void SetAuth(string auth)
		{
			_auth = auth;
		}
	}
}
