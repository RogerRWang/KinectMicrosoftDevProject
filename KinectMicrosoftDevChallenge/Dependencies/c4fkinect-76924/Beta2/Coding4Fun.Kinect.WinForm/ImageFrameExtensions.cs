// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Security;
using Coding4Fun.Kinect.Common;

using Microsoft.Research.Kinect.Nui;

namespace Coding4Fun.Kinect.WinForm
{
    public static class ImageFrameExtensions
    {
		public static short[][] ToDepthArray2D(this ImageFrame image)
		{
			return ImageFrameCommonExtensions.ToDepthArray2D(image);
		}

		public static short[] ToDepthArray(this ImageFrame image)
		{
			return ImageFrameCommonExtensions.ToDepthArray(image);
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
		public static short GetDistance(this ImageFrame image, int x, int y)
		{
			return ImageFrameCommonExtensions.GetDistance(image, x, y);
		}

		public static Point GetMidpoint(this short[] depthData, int width, int height, int startX, int startY, int endX, int endY, int minimumDistance)
        {
            double x;
            double y;

			depthData.GetMidpoint(width, height, startX, startY, endX, endY, minimumDistance, out x, out y);

            return new Point((int)x, (int)y);
        }

		// securitycritical covers this
		[SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		//[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
		[SecurityCritical]
		public static Bitmap ToBitmap(this short[] depthData, int width, int height, int minimumDistance, Color highlightColor)
        {
            if (depthData != null)
            {
                var colorFrame = new byte[height * width * 4];

                for (int colorIndex = 0, depthIndex = 0; colorIndex < colorFrame.Length; colorIndex += 4, depthIndex++)
                {
					var intensity = ImageFrameCommonExtensions.CalculateIntensityFromDepth(depthData[depthIndex]);

                    colorFrame[colorIndex + ImageFrameCommonExtensions.RedIndex] = intensity;
                    colorFrame[colorIndex + ImageFrameCommonExtensions.GreenIndex] = intensity;
                    colorFrame[colorIndex + ImageFrameCommonExtensions.BlueIndex] = intensity;

                    if (depthData[depthIndex] <= minimumDistance && depthData[depthIndex] > 0)
                    {
                        var mult = intensity / 255f;
                        var color = Color.FromArgb(
                            (int)(highlightColor.R * mult), 
                            (int)(highlightColor.G * mult),
                            (int)(highlightColor.B * mult));

						colorFrame[colorIndex + ImageFrameCommonExtensions.RedIndex] = color.R;
						colorFrame[colorIndex + ImageFrameCommonExtensions.GreenIndex] = color.G;
						colorFrame[colorIndex + ImageFrameCommonExtensions.BlueIndex] = color.B;
                    }
                }

				return colorFrame.ToBitmap(width, height);
            }

            return null;
        }

		// securitycritical covers this
		[SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		//[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
		[SecurityCritical]
        public static Bitmap ToBitmap(this ImageFrame image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            switch (image.Type)
            {
                case ImageType.Color:
                    {
                        return image.Image.Bits.ToBitmap(image.Image.Width, image.Image.Height);
                    }
                case ImageType.Depth:
                    {
						return ImageFrameCommonExtensions.ConvertDepthFrameDataToBitmapData(image.Image.Bits, image.Image.Width, image.Image.Height).ToBitmap(image.Image.Width, image.Image.Height);
                    }
                case ImageType.DepthAndPlayerIndex:
                    {
						return ImageFrameCommonExtensions.ConvertDepthFrameDataWithSkeletonToBitmapData(image.Image.Bits, image.Image.Width, image.Image.Height).ToBitmap(image.Image.Width, image.Image.Height);
                    }
                default:
                    return null;
            }
        }
    }
}
