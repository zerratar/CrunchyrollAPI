using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CrunchyrollApi;
using CrunchyrollApi.Classes;
using FingerFeat.CrunchyrollApi.Classes.Models;
using FingerFeat.CrunchyrollApi.Classes.Requests;

namespace FingerFeat.CrunchyrollApi.Classes
{
    public class CrunchyrollClient
    {

        private readonly Dictionary<string, string> _httpCache;
        private readonly ApplicationState _applicationState;
        private readonly ClientInformation _clientInformation;

        public CrunchyrollClient(ApplicationState appState, ClientInformation clientInfo)
        {
            _httpCache = new Dictionary<string, string>();
            _applicationState = appState;
            _clientInformation = clientInfo;
        }


        public async Task<VideoStreamData> GetMediaStream(int mediaId)
        {
            var streamData = new VideoStreamData();
            try
            {
                var session = _applicationState.GetSession();
                if (session.GetId() == null)
                {
                    var sessionId = await CrunchyrollSessionHandler.GetSessionId();
                    session.SetId(sessionId);
                }

                var req = new InfoRequest(mediaId);
                var response = await Run(req);
                var data = response.ResponseElement.Element("data");

                var infoData = data.Element("stream_data");
                streamData = VideoStreamData.FromXml(infoData);
            }
            catch
            {

            }

            return streamData;
        }

        public async void StartSession()
        {
            try
            {
                var session = _applicationState.GetSession();
                if (session.GetId() == null)
                {
                    var sessionId = await CrunchyrollSessionHandler.GetSessionId();
                    session.SetId(sessionId);
                }



                var req = new StartSessionRequest(_clientInformation, session.GetAuth(), null);
                var response = await RunSessionless(req, _clientInformation);
                var data = response.ResponseElement.Element("data");

                session.SetId(data.Element("session_id").Value);

            }
            catch (Exception exc)
            {



            }
        }

        public async Task<List<Media>> GetMediaList(long? collectionId, long? seriesId, string sort, int? offset, int? limit)
        {
            try
            {
                var session = _applicationState.GetSession();
                if (session.GetId() == null)
                {
                    var sessionId = await CrunchyrollSessionHandler.GetSessionId();
                    session.SetId(sessionId);
                }

                var req = new ListMediaRequest(collectionId, seriesId, sort, offset, limit);
                var response = await Run(req);
                var data = response.ResponseElement.Element("data");

                var items = data.Elements("item");
                return items.Select(Media.FromXml).ToList();
            }
            catch
            {

            }
            return new List<Media>();
        }

        public async Task<List<Series>> GetSeriesList(string mediatype, string filter, int offset, int limit)
        {
            try
            {
                var session = _applicationState.GetSession();
                if (session.GetId() == null)
                {
                    var sessionId = await CrunchyrollSessionHandler.GetSessionId();
                    session.SetId(sessionId);
                }

                var req = new ListSeriesRequest(mediatype, filter, offset, limit);
                var response = await Run(req);
                var data = response.ResponseElement.Element("data");

                var items = data.Elements("item");
                return items.Select(Series.FromXml).ToList();
            }
            catch
            {

            }
            return new List<Series>();
        }

        public async Task<bool> Login(string username, string password)
        {
            try
            {
                var session = _applicationState.GetSession();
                if (session.GetId() == null)
                {
                    var sessionId = await CrunchyrollSessionHandler.GetSessionId();
                    session.SetId(sessionId);
                }

                var loginReq = new LoginRequest(username, password);
                var response = await Run(loginReq);
                var data = response.ResponseElement;

                var xElement = data.Element("data");
                if (xElement != null)
                {
                    var userElm = xElement.Element("user");
                    if (userElm != null)
                    {
                        var user = new User(userElm.Element("username").Value,
                                            userElm.Element("email").Value,
                                            userElm.Element("premium").Value);
                        session.SetUser(user);
                    }
                    _applicationState.SetLoggedInUser(session.GetUser());
                    var authElm = xElement.Element("auth");
                    if (authElm != null) { session.SetAuth(authElm.Value); _applicationState.SetAuth(authElm.Value); }
                }

                return true;
            }
            catch
            {
                return false;
            }

        }


        public async Task<string> FetchRequest(ApiRequest request, Dictionary<string, string> param)
        {
            var req = (HttpWebRequest)HttpWebRequest.Create(request.GetUrl());

            req.Method = request.GetRequestMethod();

            if (param == null)
                param = request.GetParams();

            //var resStr = req.MakePost(_clientInformation, param);

            // req.AddWindowsPhoneHeaders();//AddAndroidHeaders(paramClientInformation);

            var encoding = new UTF8Encoding();
            var d2 = param.Keys.Select(k => k + "=" + param[k]).ToList();

            string postData = string.Join("&", d2);
            byte[] data = encoding.GetBytes(postData);

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            // req.ContentLength = data.Length;

            var stream = await req.GetRequestStreamAsync();
            using (stream)
            {
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }

            var resp = (HttpWebResponse)(await req.GetResponseAsync());
            string resStr;
            using (resp)
            {                
                using (var respoStream = new StreamReader(resp.GetResponseStream()))
                {
                    resStr = respoStream.ReadToEnd();                    
                }                
                req.Abort();
            }
            return resStr;
        }

        private async Task<ApiResponse> dispatchRequest(ApiRequest paramApiRequest, Dictionary<string, string> paramSet)
        {
            String str1 = paramApiRequest.GetUrl();
            Dictionary<string, string> localMap = paramApiRequest.GetParams();
            //hash
            //var localHashCode = hashFunction.newHasher().putString(str1).putInt(localMap.GetHashCode().hashCode()).hash();
            //TokenBuffer localTokenBuffer1 = (TokenBuffer)this.httpCache.ContainsValue(localHashCode);
            // ObjectMapper localObjectMapper = (ObjectMapper)this.mapperProvider.get();
            // if (localTokenBuffer1 == null);
            var xElm = new XElement("empty");
            var localHashCode = localMap.GetHashCode();
            try
            {
                var xml = await FetchRequest(paramApiRequest, paramSet);
                xElm = XElement.Parse(xml);
                var hasError = bool.Parse(xElm.Element("error").Value);
                if (hasError)
                {
                    var errorCode = xElm.Element("code").Value;
                    var errorMessage = xElm.Element("message").Value;
                }
            }
            //catch (JsonParseException localJsonParseException)
            catch (Exception)
            {
                //JsonParseException
                //TokenBuffer localTokenBuffer2;
                //while (true)
                //{
                //  throw new ApiBadResponseException(localJsonParseException);
                //  localTokenBuffer2 = localTokenBuffer1;
                //}
            }

            var localApiResponse = new ApiResponse(localHashCode, xElm, this._httpCache);
            return localApiResponse;
        }

        private async Task<ApiResponse> dispatchRequestAndRetry(ApiRequest paramApiRequest, Dictionary<string, string> paramSet, int paramInt)
        {
            while (true)
            {
                ApiResponse localApiResponse1;
                long l;
                try
                {
                    //Ln.e("Dispatch and retry", new Object[0]);
                    ApiResponse localApiResponse2 = await dispatchRequest(paramApiRequest, paramSet);
                    localApiResponse1 = localApiResponse2;
                    return localApiResponse1;
                }
                catch (Exception localApiBadSessionException)
                {
                    //int i = Double.valueOf(Math.pow(2.0D, paramInt)).intValue();
                    //Object[] arrayOfObject = new Object[1];
                    //arrayOfObject[0] = Integer.valueOf(i);
                    //Ln.e("Bad session! Trying again in %d seconds", arrayOfObject);
                    //l = i * 1000;
                }
                
                //System.Threading.Thread.Sleep(10);
                try
                {
                    //OpenSession();
                    return await dispatchRequestAndRetry(paramApiRequest, paramSet, paramInt + 1);
                }
                catch (Exception)
                //catch (InterruptedException localInterruptedException)
                {
                    //break label82;
                }							
            }
        }

        public async Task<ApiResponse> Run(ApiRequest paramApiRequest)
        {
            return await Run(paramApiRequest, null);
        }

        public async Task<ApiResponse> Run(ApiRequest paramApiRequest, Dictionary<string, string> paramSet)
        {
            return await dispatchRequestAndRetry(new ApiSingleRequestWrapper(paramApiRequest, _applicationState.GetSession().GetId(), new List<string>()), paramSet, 0);
        }

        public async Task<ApiResponse> RunSessionless(ApiRequest paramApiRequest, ClientInformation paramClientInformation)
        {
            return await dispatchRequest(new ApiSingleRequestWrapper(paramApiRequest, paramClientInformation, null), null);
        }
    }
}
