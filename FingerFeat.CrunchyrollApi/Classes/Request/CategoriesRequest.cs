using System.Collections.Generic;
using CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes.Requests
{
    public class CategoriesRequest : AbstractApiRequest
    {
        public CategoriesRequest(string mediaType)
        {
            MediaType = mediaType;
        }

        protected string MediaType
        {
            get;
            set;
        }

        public override string GetApiMethod()
        {
            return "categories";
        }

        public override string GetRequestMethod()
        {
            return "GET";
        }

        public override Dictionary<string, string> GetParams()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("media_type",MediaType);
            return dict;
        }
    }
}
