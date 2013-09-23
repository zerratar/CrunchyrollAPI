using System.Linq;
using System.Windows;

namespace FingerFeat.CrunchyrollApi.Sample
{
	using FingerFeat.CrunchyrollApi.Classes;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			//
			// Some initialization objects required, basically so you can more easily
			// keep track of the appstate and clientInfo.. yada yada..
			//
			var appState = new ApplicationState();
			var clientInfo = new ClientInformation();

			// Hoozam! Our client!
			var crClient = new CrunchyrollClient(appState, clientInfo);
			if (await crClient.Login("my_username", "my_password"))
			{
				// And Hoozam! We are logged in.. :3 Lets start our session.                
				crClient.StartSession();

				// For the sake of it.. Lets grab some series and shizzle!
				// In this case: We are looking for anime, grabbing max 50 series, starting offset 0
				var series = await crClient.GetSeriesList("anime", null, 0, 50);

				foreach (var serie in series)
				{
					// ... Do something fancy with them all!
				}

				// .. Or do something fancy with a specific one!
				var SOA = series.FirstOrDefault(s => s.Name.ToLower().StartsWith("sword art online"));
				if (SOA != null)
				{
					var episodes = await crClient.GetMediaList(null, SOA.SeriesId, null, null, null);

					foreach (var episode in episodes)
					{
						// ... FANCY THINGS!
					}

					// Or just one of em..
					var firstEpisode = episodes.FirstOrDefault();
					if (firstEpisode != null)
					{
						var streamData = await crClient.GetMediaStream(firstEpisode.MediaId);
						// .. from the streamData object you'll get a few video urls, 
						// information about its bitrate, what language it is played in, etc. etc...
						// now its time for you to play the video :) !
						var firstStream = streamData.Streams.FirstOrDefault();
						if (firstStream != null)
						{
							var videoURL = firstStream.Url;
							// HAVE FUN!
						}
					}
				}
			}
		}
	}
}
