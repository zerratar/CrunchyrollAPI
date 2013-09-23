using System.Collections.Generic;
using System.Globalization;
using CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes.Requests
{
    public class ListSeriesRequest : AbstractApiRequest
    {

        public ListSeriesRequest(string mediaType, string filter, int offset, int limit)
        {
            MediaType = mediaType;
            Filter = filter;
            Offset = offset;
            Limit = limit;
        }

        protected string MediaType
        {
            get;
            set;
        }

        protected string Filter
        {
            get;
            set;
        }

        protected int Offset
        {
            get;
            set;
        }

        protected int Limit
        {
            get;
            set;
        }

        public override string GetApiMethod()
        {
            return "list_series";
        }

        public override string GetRequestMethod()
        {
            return "GET";
        }

        public override Dictionary<string, string> GetParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("media_type", MediaType);
            if (Filter != null)
                dict.Add("filter", Filter);
            if (Offset > 0)
                dict.Add("offset", Offset.ToString(CultureInfo.InvariantCulture));
            if (Limit > 0)
                dict.Add("limit", Limit.ToString(CultureInfo.InvariantCulture));
            return dict;
        }
    }
}
