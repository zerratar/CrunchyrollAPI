using System;
using System.Xml.Linq;

namespace FingerFeat.CrunchyrollApi.Classes.Models
{
	public class Media
	{
		public string AvailabilityNotes { get; set; }
		public string Description { get; set; }
		public string EpisodeNumber { get; set; }
		public string MediaType { get; set; }
		public string Name { get; set; }
		public string SeriesName { get; set; }
		public string AvailableNotes { get; set; }

		public string Url { get; set; }
		public string BifUrl { get; set; }

		public bool Clip { get; set; }
		public bool Available { get; set; }
		public bool IsFreeAvailable { get; set; }
		public bool IsPremiumAvailable { get; set; }

		public DateTime AvailableTime { get; set; }
		public DateTime UnavailableTime { get; set; }
		public DateTime PremiumAvailableTime { get; set; }
		public DateTime PremiumUnavailableTime { get; set; }
		public DateTime FreeAvailableTime { get; set; }
		public DateTime FreeUnavailableTime { get; set; }

		public int MediaId { get; set; }
		public long SeriesId { get; set; }
		public long CollectionId { get; set; }

		public int Playhead { get; set; }

		public ImageSet ScreenshotImage { get; set; }
		public VideoStreamData StreamData { get; set; }


		public static Media FromXml(XElement elm)
		{
			var media = new Media();
			if (elm != null)
			{
				media.MediaType = elm.Element("class").Value;
				media.MediaId = int.Parse(elm.Element("media_id").Value);
				media.CollectionId = long.Parse(elm.Element("collection_id").Value);
				media.SeriesId = long.Parse(elm.Element("series_id").Value);
				media.EpisodeNumber = elm.Element("episode_number").Value;
				media.Name = elm.Element("name").Value;
				media.MediaType = elm.Element("media_type").Value;
				media.Description = elm.Element("description").Value;
				media.ScreenshotImage = ImageSet.FromXml(elm.Element("screenshot_image"));

			}
			return media;
		}


	}
}
