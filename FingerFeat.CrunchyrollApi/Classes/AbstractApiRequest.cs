using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FingerFeat.CrunchyrollApi.Classes;

namespace CrunchyrollApi.Classes
{
	public abstract class AbstractApiRequest : ApiRequest
	{
		private static long serialVersionUID = -4362805173765535708L;

		public override string GetUrl()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append(IsSecure() ? "https://" : "http://");

			return stringBuilder
					.Append("api.Crunchyroll.com/")
					.Append(GetApiMethod() + ".")
					.Append(GetVersion() + ".")
					.Append("xml").ToString();
		}

		public override int GetVersion()
		{
			return 0;
		}

		public override bool IsSecure()
		{
			return true;
		}

		//public abstract string GetApiMethod();

		//public override string GetRequestMethod()
		//{
		//    throw new NotImplementedException();
		//}

		//public override Dictionary<string, string> GetParams()
		//{
		//    throw new NotImplementedException();
		//}
	}
}
