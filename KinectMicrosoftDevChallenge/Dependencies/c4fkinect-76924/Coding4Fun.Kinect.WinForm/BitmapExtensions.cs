// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace Coding4Fun.Kinect.WinForm
{
    public static class BitmapExtensions
    {
        public static void Save(this Image source, string filePath, ImageFormat format)
        {
            if (source == null)
                return;

            System.Drawing.Imaging.ImageFormat imgFormat = null;
            switch (format)
            {
                case ImageFormat.Png:
                    imgFormat = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                case ImageFormat.Jpeg:
                    imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
                case ImageFormat.Bmp:
                    imgFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
            }

            if (imgFormat != null)
                using(var stream = new FileStream(filePath, FileMode.Create))
                    source.Save(stream, imgFormat);
        }

		// returning the bitmap, me disposing it would destroy object before other could use it
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		// securitycritical covers this
		[SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		//[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
		[SecurityCritical]
		public static Bitmap ToBitmap(this byte[] pixels, int width, int height)
		{
			return ToBitmap(pixels, width, height, PixelFormat.Format32bppRgb);
		}

		// returning the bitmap, me disposing it would destroy object before other could use it
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		// securitycritical covers this
		[SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		//[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
		[SecurityCritical]
		public static Bitmap ToBitmap(this byte[] pixels, int width, int height, PixelFormat format)
		{
			if (pixels == null)
				return null;

			var bitmap = new Bitmap(width, height, format);

			var data = bitmap.LockBits(
				new Rectangle(0, 0, bitmap.Width, bitmap.Height),
				ImageLockMode.ReadWrite,
				bitmap.PixelFormat);

			Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);

			bitmap.UnlockBits(data);

			return bitmap;
		}
    }
}