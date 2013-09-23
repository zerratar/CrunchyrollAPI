CrunchyrollAPI
==============

An open source Crunchyroll API made in C#

 I could just start by saying, enjoy! Use it in any way you want.
 This wrapper is not complete, but all the "important" functionality
 is available. 
  
  * **Login( user, pass )**
	Logs you in, MUST BE DONE before anything else. Otherwise the other requests wont have any effect :p
	  
  * **StartSession()**
	This will start the session, also required to get stream data
    
  * **GetSeriesList( mediaType, filter, offset, limit )**
    - [Optional] mediaType can be either "drama" or "anime"
    - [Optional] filter is the different type of categories, such as "adventure", "action", etc.. 
    - offset, i suggest using 0 if you're not sure.
    - limit, how many series will be in the response, use 0 for all.	
	Gives you a list of available series that you can watch, given the type of account you got.
	
  
  * **GetMediaList( collectionId, seriesId, sort, offset, limit )**
    - [Optional] collectionId
    - [Required] seriesId
    - [Optional] offset
    - [Optional] limit
	Gives you a list of episodes a specific serie has

  
  * **GetMediaStream( mediaId/episodeId )**
    - [Required, you silly!] mediaId
	Gives you a list of different available streams and video qualities.
	NOTE: StartSession must have been used before this request	

==============
 The unfortenate part. I'm not able to create a WP8 specific project at this time as I'm not currently
 using a Windows 8 installation, the Windows Store App Lib however is available as I had time to do it earlier =)
 
 Now for the fortunate part,
 the code is pretty much cross-platform between the different devices WP7, WP8 and even Win8 Store App. 
 So all you have to do is to rebuild the different projects. (I'm not able to try it out atm, it could give you them horrible errors)

 ==============
 
 HOW TO USE
 
  Here goes nothing!!
  Just a few simple steps and you should be all goody!
  
  1. Add the library (after build preferrably) as reference to your Visual Studio 2010/2012 project. (This is library is built using .NET Framework 4.5 though, so Visual Studio 2012 is recommended)
     (Q. Will Express version of Visual Studio work?? -- A. No idea what so ever, but why dont you just try it instead of reading this answer?)
	^
	|__ lol :D

  2. magic!
 
 C# EXAMPLE  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Some initialization objects required, basically so you can more easily
            // keep track of the appstate and clientInfo.. yada yada..
            //
            var appState = new ApplicationState();
            var clientInfo = new ClientInformation();

            // Hoozam! Our client!
            var crClient = new CrunchyrollClient(appState, clientInfo);
            if(await crClient.Login("my_username", "my_password"))
            {                
                // And Hoozam! We are logged in.. :3 Lets start our session.                
                crClient.StartSession();
                
                // For the sake of it.. Lets grab some series and shizzle!
                // In this case: We are looking for anime, grabbing max 50 series, starting offset 0
                var series = await crClient.GetSeriesList("anime", null, 0, 50);

                foreach(var serie in series)
                {
                    // ... Do something fancy with them all!
                }

                // .. Or do something fancy with a specific one!
                var SOA = series.FirstOrDefault(s => s.Name.ToLower().StartsWith("sword art online"));
                if(SOA != null)
                {
                    var episodes = await crClient.GetMediaList(null, SOA.SeriesId, null, null, null);

                    foreach(var episode in episodes)
                    {
                        // ... FANCY THINGS!
                    }

                    // Or just one of em..
                    var firstEpisode = episodes.FirstOrDefault();
                    if(firstEpisode != null)
                    {
                        var streamData = await crClient.GetMediaStream(firstEpisode.MediaId);
                        // .. from the streamData object you'll get a few video urls, 
                        // information about its bitrate, what language it is played in, etc. etc...
                    }
                }
            }
        }
    }
}
 
 -------- Since i havnt used VB in ages, can't say for sure how to use the Async part there, therefor i'm not providing an example for it. BUT! I guess it should work :p


 -- I hope you enjoyed this thing, even though its not complete and would need some time to refactor the code, pretty sloppy atm (i just wanted it to work xD)
 -- Got questions? e-mail meeee! 
  - zerratar@gmail.com or kpj@fingerfeat.com either works good!
