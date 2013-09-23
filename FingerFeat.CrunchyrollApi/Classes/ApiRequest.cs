using System.Collections.Generic;

namespace FingerFeat.CrunchyrollApi.Classes
{
	public abstract class ApiRequest
	{
		public abstract string GetApiMethod();

		public abstract string GetRequestMethod();

		public abstract Dictionary<string, string> GetParams();

		public abstract string GetUrl();

		public abstract int GetVersion();

		public abstract bool IsSecure();
	}
}
