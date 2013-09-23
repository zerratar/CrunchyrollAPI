using System.Collections.Generic;
using CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes.Requests
{
	public class InfoRequest : AbstractApiRequest
    {
		private long? _mediaId;

		public InfoRequest(long? media_id)
		{
			_mediaId = media_id;
        }

		public override string GetApiMethod()
		{
			return "info";
		}

		public override string GetRequestMethod()
		{
			return "POST";
		}

		public override Dictionary<string, string> GetParams()
		{
			var param = new Dictionary<string, string>();
			param.Add("media_id", _mediaId.GetValueOrDefault().ToString());
			//param.Add("session_id", _session);//"pvjt1wu1fqnz26nwjvzjudvcwrlhkact");
			param.Add("fields", "media.stream_data");
			return param;
		}
	}
}
