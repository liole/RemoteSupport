using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.Helpers
{
	public class ImageHelper
	{
		public static Rectangle? DiffBounds(Bitmap image1, Bitmap image2)
		{
			// Lock the bitmap's bits.  
			Rectangle rect = new Rectangle(0, 0, image1.Width, image1.Height);
			BitmapData bmp1Data = image1.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			BitmapData bmp2Data = image2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

			// Get the address of the first line.
			IntPtr ptr1 = bmp1Data.Scan0;
			IntPtr ptr2 = bmp2Data.Scan0;

			// Declare an array to hold the bytes of the bitmap.
			int size = bmp1Data.Stride * image1.Height;
			byte[] rgbValues1 = new byte[size];
			byte[] rgbValues2 = new byte[size];

			// Copy the RGB values into the array.
			Marshal.Copy(ptr1, rgbValues1, 0, size);
			Marshal.Copy(ptr2, rgbValues2, 0, size);

			int stride = bmp1Data.Stride;

			int maxX = 0;
			int maxY = 0;
			int minX = image1.Width + 1;
			int minY = image1.Height + 1;

			for (int column = 0; column < bmp1Data.Height; column++)
			{
				for (int row = 0; row < bmp1Data.Width; row++)
				{
					var b1 = (byte)(rgbValues1[(column * stride) + (row * 3)]);
					var g1 = (byte)(rgbValues1[(column * stride) + (row * 3) + 1]);
					var r1 = (byte)(rgbValues1[(column * stride) + (row * 3) + 2]);

					var b2 = (byte)(rgbValues2[(column * stride) + (row * 3)]);
					var g2 = (byte)(rgbValues2[(column * stride) + (row * 3) + 1]);
					var r2 = (byte)(rgbValues2[(column * stride) + (row * 3) + 2]);

					var diff = r1 != r2 || g1 != g2 || b1 != b2;

					if (diff)
					{
						if (column > maxY) maxY = column;
						if (column < minY) minY = column;
						if (row > maxX) maxX = row;
						if (row < minX) minX = row;
					}
				}
			}

			image1.UnlockBits(bmp1Data);
			image2.UnlockBits(bmp2Data);

			if (minX > maxX || minY > maxY)
			{
				return null;
			}

			return new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
		}
	}
}
