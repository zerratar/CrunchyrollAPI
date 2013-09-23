using System;
using System.Globalization;

namespace FingerFeat.CrunchyrollApi.Classes.Models
{
	public class UUID
	{
		private long _leastSigBits;
		private long _mostSigBits;

		public UUID()
		{

		}

		public UUID(long mostSigBits, long leastSigBits)
		{
			_mostSigBits = mostSigBits;
			_leastSigBits = leastSigBits;
		}

		public UUID(byte[] data)
		{
			long msb = 0;
			long lsb = 0;
			// assert data.length == 16 : "data must be 16 bytes in length";
			for (int i = 0; i < 8; i++)
				msb = (msb << 8) | (data[i] & 0xff);
			for (int i = 8; i < 16; i++)
				lsb = (lsb << 8) | (data[i] & 0xff);
			_mostSigBits = msb;
			_leastSigBits = lsb;
		}

		public static UUID Parse(String name)
		{
			var components = name.Split('-');

			if (components.Length != 5)
				throw new ArgumentException("Invalid UUID string: " + name);
			//throw new IllegalArgumentException("Invalid UUID string: " + name);

			for (var i = 0; i < 5; i++)
				components[i] = "0x" + components[i];

			var mostSigBits = long.Parse(components[0], NumberStyles.HexNumber);
			mostSigBits <<= 16;
			mostSigBits |= long.Parse(components[1], NumberStyles.HexNumber);
			mostSigBits <<= 16;
			mostSigBits |= long.Parse(components[2], NumberStyles.HexNumber);

			var leastSigBits = long.Parse(components[3], NumberStyles.HexNumber);
			leastSigBits <<= 48;
			leastSigBits |= long.Parse(components[4], NumberStyles.HexNumber);

			return new UUID(mostSigBits, leastSigBits);
		}

		private static String digits(long val, int digits)
		{
			long hi = 1L << (digits * 4);

			return (hi | (val & (hi - 1))).ToString("X").Substring(1);
		}

		public override string ToString()
		{
			return (digits(_mostSigBits >> 32, 8) + "-" +
					digits(_mostSigBits >> 16, 4) + "-" +
					 digits(_mostSigBits, 4) + "-" +
					 digits(_leastSigBits >> 48, 4) + "-" +
					 digits(_leastSigBits, 12));
		}
	}
}
