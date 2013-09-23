using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FingerFeat.CrunchyrollApi.Classes;

namespace CrunchyrollApi.Classes
{

	public class ApiBatchRequestWrapper : ApiRequest
	{
		private static long serialVersionUID = -172665767012508694L;
		private Dictionary<string, string> fields;
		private string method;
		//private ObjectMapper objectMapper;
		private List<ApiRequest> requests;
		private string sessionId;

		public ApiBatchRequestWrapper(List<ApiRequest> paramList, string paramRequestMethod, string paramString, Dictionary<string, string> paramSet/*, ObjectMapper paramObjectMapper*/)
		{
			//if (paramString == null)
			//  throw new IllegalArgumentException("sessionId must not be null");
			this.requests = paramList;
			this.method = paramRequestMethod;
			this.sessionId = paramString;
			this.fields = paramSet;
			//this.objectMapper = paramObjectMapper;
		}

		public override string GetApiMethod()
		{
			return "batch";
		}

		public override string GetRequestMethod()
		{
			return method;
		}

		public override Dictionary<string, string> GetParams()
		{
			var localBuilder = new Dictionary<string, string>();
			localBuilder.Add("locale", "enUS");
			localBuilder.Add("fields", "user.username,user.premium,user.email");
			//ByteArrayOutputStream localByteArrayOutputStream;
			//JsonGenerator localJsonGenerator;
			//try
			//{
			//    localByteArrayOutputStream = new ByteArrayOutputStream();
			//    localJsonGenerator = this.objectMapper.getJsonFactory().createJsonGenerator(localByteArrayOutputStream);
			//    localJsonGenerator.writeStartArray();
			//    Iterator localIterator = this.requests.iterator();
			//    while (localIterator.hasNext())
			//    {
			//        ApiRequest localApiRequest = (ApiRequest)localIterator.next();
			//        localJsonGenerator.writeStartObject();
			//        localJsonGenerator.writeStringField("method", localApiRequest.getMethod().name());
			//        localJsonGenerator.writeStringField("api_method", localApiRequest.getApiMethod());
			//        localJsonGenerator.writeNumberField("method_version", localApiRequest.getVersion());
			//        localJsonGenerator.writeObjectField("params", localApiRequest.getParams());
			//        localJsonGenerator.writeEndObject();
			//    }
			//}
			//catch (IOException localIOException)
			//{
			//    Ln.e(localIOException);
			//    throw new ApiUnknownException("Problem encoding batch request.", localIOException);
			//}
			//localJsonGenerator.writeEndArray();
			//localJsonGenerator.close();
			//String str = localByteArrayOutputStream.toString();
			//localByteArrayOutputStream.close();
			//localBuilder.put("requests", str);
			localBuilder.Add("session_id", sessionId);
			return localBuilder;
		}

		public override string GetUrl()
		{
			var localStringBuilder = new StringBuilder();
			localStringBuilder.Append(IsSecure() ? "https://" : "http://");
			localStringBuilder.Append("api.crunchyroll.com").Append("/");
			localStringBuilder.Append(GetApiMethod()).Append(".");
			localStringBuilder.Append(GetVersion()).Append(".");
			localStringBuilder.Append("xml");
			return localStringBuilder.ToString();
		}

		public override int GetVersion()
		{
			return 0;
		}

		public override bool IsSecure()
		{
			return true;
		}
	}
}
