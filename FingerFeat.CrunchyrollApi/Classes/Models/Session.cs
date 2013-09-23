using System;

namespace FingerFeat.CrunchyrollApi.Classes.Models
{
	public class Session
	{
		private string _auth;
		private string _countryCode;
		private string _id;
		private User _user;

		public string GetAuth()
		{
			return _auth;
		}

		public String GetCountryCode()
		{
			return _countryCode;
		}

		public String GetId()
		{
			return _id;
		}

		public User GetUser()
		{
			return _user;
		}


		public void SetAuth(string paramString)
		{
			_auth = paramString;
		}

		public void SetCountryCode(string paramString)
		{
			_countryCode = paramString;
		}

		public void SetId(string paramString)
		{
			_id = paramString;
		}

		public void SetUser(User paramUser)
		{
			_user = paramUser;
		}
	}
}
