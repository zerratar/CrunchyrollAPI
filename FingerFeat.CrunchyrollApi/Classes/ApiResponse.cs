using System.Collections.Generic;

namespace FingerFeat.CrunchyrollApi.Classes
{
	public class ApiResponse
	{
		private int localHashCode;
		public System.Xml.Linq.XElement ResponseElement;
		public  Dictionary<string, string> dictionary;

		public ApiResponse(int localHashCode, System.Xml.Linq.XElement xElement, Dictionary<string, string> dictionary)
		{
			// TODO: Complete member initialization
			this.localHashCode = localHashCode;
            this.ResponseElement = xElement;
			this.dictionary = dictionary;
		}
	}
}
