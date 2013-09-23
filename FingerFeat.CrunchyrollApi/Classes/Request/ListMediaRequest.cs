using System.Collections.Generic;
using System.Globalization;
using CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes.Requests
{
    public class ListMediaRequest : AbstractApiRequest
    {

        public ListMediaRequest(long? collectionid, long? seriesid, string sort, int? offset, int? limit)
        {
            CollectionId = collectionid;
            SeriesId = seriesid;
            Sort = sort;
            Offset = offset;
            Limit = limit;
        }

        protected string Sort
        {
            get;
            set;
        }

        protected int? Offset
        {
            get;
            set;
        }

        protected int? Limit { get; set; }

        protected long? SeriesId
        {
            get;
            set;
        }

        protected long? CollectionId
        {
            get;
            set;
        }

        public override string GetApiMethod()
        {
            return "list_media";
        }

        public override string GetRequestMethod()
        {
            return "GET";
        }

        public override Dictionary<string, string> GetParams()
        {
            var dict = new Dictionary<string, string>();
            if (CollectionId.HasValue)
                dict.Add("collection_id", CollectionId.Value.ToString(CultureInfo.InvariantCulture));
            if (SeriesId.HasValue)
                dict.Add("series_id", SeriesId.Value.ToString(CultureInfo.InvariantCulture));
            if (Sort != null)
                dict.Add("sort", Sort);
            if (Offset.HasValue)
                dict.Add("offset", Offset.Value.ToString(CultureInfo.InvariantCulture));
            if (Limit.HasValue)
                dict.Add("limit", Limit.Value.ToString(CultureInfo.InvariantCulture));
            return dict;
        }
    }
}
