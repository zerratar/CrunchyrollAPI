using System.Xml.Linq;

namespace FingerFeat.CrunchyrollApi.Classes.Models
{
    public class Series
    {
        public long SeriesId { get; set; }
        public string MediaType { get; set; }
        public bool InQueue { get; set; }
        public int MediaCount { get; set; }
        public ImageSet PortraitImage { get; set; }
        public ImageSet LandscapeImage { get; set; }
        public string PublisherName { get; set; }
        public string Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public static Series FromXml(XElement elm)
        {
            var serie = new Series();
            if (elm != null)
            {
                serie.MediaType = elm.Element("class").Value;
                serie.SeriesId = long.Parse(elm.Element("series_id").Value);
                serie.Url = elm.Element("url").Value;
                serie.Name = elm.Element("name").Value;
                serie.MediaType = elm.Element("media_type").Value;
                serie.Description = elm.Element("description").Value;
                //serie.MediaCount = int.Parse(elm.Element("media_count").Value);
                var landscape = elm.Element("landscape_image");
                if(landscape!=null)
                {
                    serie.LandscapeImage = ImageSet.FromXml(landscape);
                }

                var portrait = elm.Element("portrait_image");
                if (portrait != null)
                {
                    serie.PortraitImage = ImageSet.FromXml(portrait);
                }
            }
            return serie;
        }
    }
}
