using System;
using System.Data.Linq;

namespace Algorithms
{
	public class Addition
	{
		public Addition ()
		{
		}

		public int BinaryAddition(Binary a, Binary b)
		{
			Binary c = new Binary(new Byte[a.Length + 1]);
			int key = 0;
			byte[] byteArray = c.ToArray ();
			for (int i = a.Length - 1; i >= 0; i--)
			{
				byte sum = (byte)((byte)(a.ToArray () [i]) + (byte)(b.ToArray () [i]) + (byte)key);
				byteArray[i + 1] = (byte)(sum % 2);
				key = (int)(sum / 2);
			}
			byteArray [0] = (byte)key;
			c = byteArray;

			string x = null;
			for (int i = 0; i < c.Length; i++)
			{
				x += c.ToArray () [i];
			}
			return Convert.ToInt32 (x, 2);
		}
	}
}

