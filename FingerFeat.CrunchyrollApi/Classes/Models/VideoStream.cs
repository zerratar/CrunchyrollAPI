using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FingerFeat.CrunchyrollApi.Classes.Models
{
	public class VideoStream
	{
		public int Bitrate { get; set; }
		public DateTime Expires { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public string Quality { get; set; }
		public string Url { get; set; }
		public long VideoEncodeId { get; set; }
		public long VideoId { get; set; }

		public static VideoStream FromXml(XElement elm)
		{
			var stream = new VideoStream();
			stream.Quality = elm.Element("quality").Value;
			stream.Bitrate = int.Parse(elm.Element("bitrate").Value);
			stream.Height = int.Parse(elm.Element("height").Value);
			stream.Width = int.Parse(elm.Element("width").Value);
			stream.Expires = DateTime.Parse(elm.Element("expires").Value);
			stream.VideoEncodeId = int.Parse(elm.Element("video_encode_id").Value);
			stream.VideoId = int.Parse(elm.Element("video_id").Value);
			stream.Url = elm.Element("url").Value;
			return stream;
		}

		public static List<VideoStream> ListFromXml(XElement element)
		{
			var l = new List<VideoStream>();
			if (element != null)
				l.AddRange(element.Elements("item").Select(FromXml));
			return l;
		}
	}
}
