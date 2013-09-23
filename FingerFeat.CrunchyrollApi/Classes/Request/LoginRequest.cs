using System;
using System.Collections.Generic;
using CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes.Requests
{
	public class LoginRequest : AbstractApiRequest
	{
		private string _account;
		private string _password;
		private string _duration;

	    public LoginRequest(string username, string password)
		{
			_account = Uri.EscapeDataString(username);
			_password = password;
			_duration = null;
		}

		public override string GetApiMethod()
		{
			return "login";
		}

		public override string GetRequestMethod()
		{
			return "POST";
		}

		public override Dictionary<string, string> GetParams()
		{
			var param = new Dictionary<string, string>();
			param.Add("account", _account);
			param.Add("password", _password);
            //param.Add("session_id", _session);//"pvjt1wu1fqnz26nwjvzjudvcwrlhkact");
			if (_duration != null)
				param.Add("duration", _duration);
            param.Add("fields", "user.username,user.premium,user.email");
			return param;
		}

		public override string ToString()
		{
			return "LoginRequest [getParams()=" + GetParams() + "]";
		}
	}
}
