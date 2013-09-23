using System.Collections.Generic;
using System.Xml.Linq;

namespace FingerFeat.CrunchyrollApi.Classes.Models
{
	public class VideoStreamData
	{
		public string AudioLanguage { get; set; }
		public string Format { get; set; }
		public string HardsubLanguage { get; set; }
		public List<VideoStream> Streams { get; set; }

		public static VideoStreamData FromXml(XElement elm)
		{			
			var vsd = new VideoStreamData();
			vsd.HardsubLanguage = elm.Element("hardsub_lang").Value;
			vsd.AudioLanguage = elm.Element("audio_lang").Value;
			vsd.Format = elm.Element("format").Value;
			vsd.Streams = VideoStream.ListFromXml(elm.Element("streams"));
			return vsd;
		}
	}
}
