using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FingerFeat.CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi
{
    public class CrunchyrollSessionHandler
    {
        private static string _formHandlerUrl = "https://www.Crunchyroll.com/ajax/";//"http://www.Crunchyroll.com/?a=formhandler";
        private static string _logoutUrl = "http://www.Crunchyroll.com/logout";
        private string _user;
        private string _pass;
        private CookieContainer _sessionCookies;

        public CrunchyrollSessionHandler(string user, string pass)
        {
            _user = user;
            _pass = pass;

            _sessionCookies = new CookieContainer();
        }

        public bool IsLoggedIn { get; set; }

        public async static Task<string> GetSessionId()
        {
            var _sessionCookies = new CookieContainer();
            var req2 = (HttpWebRequest)HttpWebRequest.Create("http://www.Crunchyroll.com/");
            req2.Method = "GET";
            
           // req2.AddBaseHeaders();
            req2.CookieContainer = _sessionCookies;
            var resp2 = await req2.GetResponseAsync();
            //var resp2 = req2.GetResponse();
            //resp2.Close();
            req2.Abort();
            var ses = _sessionCookies.GetCookies(new Uri("http://www.Crunchyroll.com/")).OfType<Cookie>().FirstOrDefault() ;
            var val = ses.Value;

            return val;
        }


        public static async void Logout()
        {
            try
            {
                var _sessionCookies = new CookieContainer();

                var logoutReq = WebRequest.Create(_logoutUrl);
                logoutReq.Method = "GET";
                await logoutReq.GetResponseAsync();
               // IsLoggedIn = false;
            }
            catch { }
        }
    }

    public static class WebRequestExtensions
    {
        public static void AddBaseHeaders(this WebRequest httpWReq)
        {
            var hreq = ((HttpWebRequest)httpWReq);
            
            hreq.Headers["User-Agent"] =
                "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_6; en-gb) AppleWebKit/528.16 (KHTML, like Gecko) Version/4.0 Safari/528.16";
            hreq.Headers["Host"] = "www.Crunchyroll.com";
            hreq.Headers["Accept-Language"] =
                "en,en-US;q=0.9,ja;q=0.8,fr;q=0.7,de;q=0.6,es;q=0.5,it;q=0.4,pt;q=0.3,pt-PT;q=0.2,nl;q=0.1,sv;q=0.1,nb;q=0.1,da;q=0.1,fi;q=0.1,ru;q=0.1,pl;q=0.1,zh-CN;q=0.1,zh-TW;q=0.1,ko;q=0.1";
            //httpWReq.Headers.Add("Accept-Encoding", "gzip, deflate");			
            hreq.Accept = "*/*";
            hreq.Headers["X-Requested-With"] = "XMLHttpRequest";
            hreq.Headers["Content-Transfer"] = "binary";
        }

        public static void AddAndroidHeaders(this HttpWebRequest httpWReq, ClientInformation paramClientInformation)
        {
            httpWReq.Headers["User-Agent"] = "Dalvik/1.6.0 (Linux; U; Android 4.0.4; GT-I9100 Build/IMM76D)";
            //httpWReq.Headers.Add("Accept-Encoding", "gzip");
            httpWReq.Headers["X-Android-Device-Manufacturer"] = paramClientInformation.GetAndroidDeviceManufacturer();
            httpWReq.Headers["X-Android-Device-Model"] = paramClientInformation.GetAndroidDeviceModel();
            httpWReq.Headers["X-Android-Device-Product"] = paramClientInformation.GetAndroidDeviceProduct();

            httpWReq.Headers["X-Android-Device-Is-GoogleTV"] = "0";
            httpWReq.Headers["X-Android-SDK"] = paramClientInformation.GetAndroidSdk().ToString();
            httpWReq.Headers["X-Android-Release"] = paramClientInformation.GetAndroidRelease();
            httpWReq.Headers["X-Android-Application-Version-Code"] = paramClientInformation.GetAndroidApplicationVersionCode().ToString();
            httpWReq.Headers["X-Android-Application-Version-Name"] = paramClientInformation.GetAndroidApplicationVersionName();
        }

        public static void AddWindowsPhoneHeaders(this HttpWebRequest httpWReq)
        {
            httpWReq.Headers["User-Agent"] = "NativeHost";
            httpWReq.Accept = "*/*";
            httpWReq.Headers["Host"] = "api.Crunchyroll.com";
            httpWReq.Headers["Accept-Encoding"] = "identity";
        }

        //public static string MakePost(this HttpWebRequest httpWReq, ClientInformation paramClientInformation, Dictionary<string, string> iDictionary)
        //{

        //}

        //public static WebRequest MakePost(this WebRequest httpWReq, params string[] postdata1)
        //{
        //    /*HttpWebRequest httpWReq =
        //        (HttpWebRequest)WebRequest.Create(url);*/

        //    httpWReq.AddBaseHeaders();

        //    var encoding = new ASCIIEncoding();

        //    string postData = string.Join("&", postdata1);
        //    //string postData = "username=user";
        //    //postData += "&password=pass";


        //    byte[] data = encoding.GetBytes(postData);

        //    httpWReq.Method = "POST";
        //    httpWReq.ContentType = "application/x-www-form-urlencoded";
        //    httpWReq.ContentLength = data.Length;

        //    using (Stream newStream = httpWReq.GetRequestStream())
        //    {
        //        newStream.Write(data, 0, data.Length);
        //    }

        //    return httpWReq;
        //}
    }
}
