using System.Collections.Generic;
using CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes.Requests
{
	public class StartSessionRequest : AbstractApiRequest
	{
		private static long serialVersionUID = 6699456696026589768L;
		private string _auth;
		private string _duration;
		private ClientInformation _clientInformation;
		public StartSessionRequest(ClientInformation clientInformation, string auth, string duration)
		{
			_clientInformation = clientInformation;
			_auth = auth;
			_duration = duration;
		}

		public override string GetApiMethod()
		{
			return "start_session";
		}

		public override string GetRequestMethod()
		{
			return "POST";//throw new NotImplementedException();
		}

		public override Dictionary<string, string> GetParams()
		{
			var dict = new Dictionary<string, string>();
			//if (_auth != null)
			//    dict.Add("auth", _auth);
			//if (_duration != null)
			//    dict.Add("duration", _duration);
			//dict.Add("fields", "user.username,user.premium,user.email");
			//dict.Add("version", "1.3.0.0");
			//if (_clientInformation != null)
			//{
			//    dict.Add("device_id", _clientInformation.GetDeviceId());
			//    dict.Add("device_type", _clientInformation.GetDeviceType());
			//    dict.Add("access_token", "z6J2faQjApno1A1");
			//}

			return dict;
		}

		public override bool IsSecure()
		{
			return false;
		}
	}
}
