using System;
using FingerFeat.CrunchyrollApi.Classes;

namespace FingerFeat.CrunchyrollApi.Classes
{
	using FingerFeat.CrunchyrollApi.Classes.Models;

	public class ClientInformation
	{
		public int GetAndroidSdk()
		{
			return 4;
		}

		public int GetAndroidDeviceIsGoogleTV()
		{
			return 0;
		}


		public string GetAndroidDeviceProduct()
		{
			return Build.PRODUCT;//throw new NotImplementedException();
		}

		public string GetAndroidDeviceModel()
		{
			return Build.MODEL;//throw new NotImplementedException();
		}

		public string GetAndroidDeviceManufacturer()
		{
			return Build.MANUFACTURER;//throw new NotImplementedException();
		}

		public string GetAndroidRelease()
		{
			return Build.VERSION.RELEASE;//throw new NotImplementedException();
		}

		public int GetAndroidApplicationVersionCode()
		{
			return 65;// null;//throw new NotImplementedException();
		}

		public string GetAndroidApplicationVersionName()
		{
			return "1.3.0.0";//throw new NotImplementedException();
		}

		public string GetDeviceId()
		{
			String str1 = "129f3hs85ke046ja";
			String str2 = "00000000000";

			return new UUID(Guid.NewGuid().GetHashCode(), str1.GetHashCode() << 32 | str2.GetHashCode()).ToString();
			
		}

		public string GetDeviceType()
		{
			return "com.Crunchyroll.winphone";
		}
	}

	public class Build
	{
		public static AndroidBuildVersionCodes VERSION_CODES;
		public static AndroidBuildVersion VERSION;
		public static string MANUFACTURER;
		public static string MODEL;
		public static string PRODUCT;
		public static string SERIAL;
		public class AndroidBuildVersion
		{
			public int SDK_INT;
			public string RELEASE;
		}

		static Build()
		{
			VERSION_CODES = AndroidBuildVersionCodes.ICE_CREAM_SANDWICH;
			MANUFACTURER = "samsung";
			MODEL = "GT-I9100";
			PRODUCT = "GT-I9100";
			VERSION = new AndroidBuildVersion();
			VERSION.SDK_INT = (int)VERSION_CODES;
			VERSION.RELEASE = "4.0.4";
			SERIAL = "00000000000";

		}
	}

	public enum AndroidBuildVersionCodes
	{
		BASE = 0x00000001,
		BASE_1_1 = 0x00000002,
		CUPCAKE = 0x00000003,
		CUR_DEVELOPMENT = 0x00002710,
		DONUT = 0x00000004,
		ECLAIR = 0x00000005,
		ECLAIR_0_1 = 0x00000006,
		ECLAIR_MR1 = 0x00000007,
		FROYO = 0x00000008,
		GINGERBREAD = 0x00000009,
		GINGERBREAD_MR1 = 0x0000000a,
		HONEYCOMB = 0x0000000b,
		HONEYCOMB_MR1 = 0x0000000c,
		HONEYCOMB_MR2 = 0x0000000d,
		ICE_CREAM_SANDWICH = 0x0000000e,
		ICE_CREAM_SANDWICH_MR1 = 0x0000000f,
		JELLY_BEAN = 0x00000010,
		JELLY_BEAN_MR1 = 0x00000011

	}
}
