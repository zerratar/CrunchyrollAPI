namespace FingerFeat.CrunchyrollApi.Classes.Models
{
    public class ImageSet
    {
        public string FWideStarUrl { get; set; }
        public string FWideUrl { get; set; }
        public string FullUrl { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string LargeUrl { get; set; }
        public string MediumUrl { get; set; }
        public string SmallUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string WideStarUrl { get; set; }
        public string WideUrl { get; set; }


        internal static ImageSet FromXml(System.Xml.Linq.XElement imageElm)
        {
            var imgSet = new ImageSet();

            if (imageElm != null)
            {
                imgSet.Width = imageElm.Element("width").Value;
                imgSet.Height = imageElm.Element("height").Value;
                imgSet.ThumbUrl = imageElm.Element("thumb_url").Value;
                imgSet.SmallUrl = imageElm.Element("small_url").Value;
                imgSet.MediumUrl = imageElm.Element("medium_url").Value;
                imgSet.LargeUrl = imageElm.Element("large_url").Value;
                imgSet.FullUrl = imageElm.Element("full_url").Value;
                imgSet.WideUrl = imageElm.Element("wide_url").Value;
                imgSet.WideStarUrl = imageElm.Element("widestar_url").Value;
                imgSet.FWideUrl = imageElm.Element("fwide_url").Value;
                imgSet.FWideUrl = imageElm.Element("fwidestar_url").Value;
            }

            return imgSet;
        }
    }
}

