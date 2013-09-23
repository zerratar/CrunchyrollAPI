using System;
using System.Collections.Generic;
using CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes
{
	public class ApiSingleRequestWrapper : ApiRequest
	{

		private static long serialVersionUID = -6779261247174816636L;
		private ClientInformation _clientInformation;
		private List<string> _fields;
		private ApiRequest _request;
		private string _sessionId;

		public ApiSingleRequestWrapper(ApiRequest paramApiRequest, ClientInformation paramClientInformation, List<string> paramSet)
		{
			//if (paramClientInformation == null)
			//throw new IllegalArgumentException("clientInformation must not be null");
			_request = paramApiRequest;
			//this.sessionId = Optional.absent();
			_clientInformation = paramClientInformation;
			_fields = paramSet;
		}

		public ApiSingleRequestWrapper(ApiRequest paramApiRequest, String paramString, List<string> fields)
		{
			/* if (paramString == null)
				throw new ApiBadResponseException("sessionId must not be null"); */
			_request = paramApiRequest;
			_sessionId = paramString;
			//this.clientInformation = Optional.absent();
			_fields = fields;
		}

		public override string GetApiMethod()
		{
			return _request.GetApiMethod();
		}

		public override string GetRequestMethod()
		{
			return _request.GetRequestMethod();
		}

		//public override Dictionary<string, string> GetParams()
		//{
		//    return _request.GetParams();
		//}

		public override Dictionary<string, string> GetParams()
		{
			var localBuilder = new Dictionary<string, string>();
			localBuilder.Add("locale", "enUS");
			if (_fields != null && _fields.Count > 0)
				localBuilder.Add("fields", string.Join(",", _fields.ToArray()));

			if(_fields==null) _fields = new List<string>();

			foreach (var qr in _request.GetParams())
				localBuilder.Add(qr.Key, qr.Value);

			if (_sessionId != null)
				localBuilder.Add("session_id", _sessionId);

			if (_clientInformation != null)
			{
				localBuilder.Add("device_id", _clientInformation.GetDeviceId());
				localBuilder.Add("device_type", _clientInformation.GetDeviceType());
				localBuilder.Add("access_token", "z6J2faQjApno1A1");
			}

			return localBuilder;
		}


		public override string GetUrl()
		{
			return _request.GetUrl();
		}

		public override int GetVersion()
		{
			return _request.GetVersion();
		}

		public override bool IsSecure()
		{
			return _request.IsSecure();
		}
	}
}
