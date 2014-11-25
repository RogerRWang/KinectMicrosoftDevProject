// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Security;
using Coding4Fun.Kinect.Common;

using Microsoft.Kinect;

namespace Coding4Fun.Kinect.WinForm
{
	public static class ImageFrameExtensions
	{

		public static short[] ToDepthArray(this DepthImageFrame image)
		{
			return ImageFrameCommonExtensions.ToDepthArray(image);
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
		public static int GetDistance(this DepthImageFrame image, int x, int y)
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
			if (depthData == null)
			{
				return null; 
			}
				//depthData must be array of distances already

				var depthColors = new byte[height * width * 4];

				for (int colorIndex = 0, depthIndex = 0; colorIndex < depthColors.Length; colorIndex += 4, depthIndex++)
				{

					//get the depth, then calculate the intensity (0-255 based on the depth)
					//depth of -1 = dark brown                

					if (depthData[depthIndex] == -1)
					{
						// dark brown
						depthColors[colorIndex + ImageFrameCommonExtensions.RedIndex] = 66;
						depthColors[colorIndex + ImageFrameCommonExtensions.GreenIndex] = 66;
						depthColors[colorIndex + ImageFrameCommonExtensions.BlueIndex] = 33;
					}
					else
					{
						var intensity = ImageFrameCommonExtensions.CalculateIntensityFromDepth(depthData[depthIndex]);

						depthColors[colorIndex + ImageFrameCommonExtensions.RedIndex] = intensity;
						depthColors[colorIndex + ImageFrameCommonExtensions.GreenIndex] = intensity;
						depthColors[colorIndex + ImageFrameCommonExtensions.BlueIndex] = intensity;

						if (depthData[depthIndex] <= minimumDistance && depthData[depthIndex] > 0)
						{
							var mult = intensity / 255f;
							var color = Color.FromArgb(
								(int)(highlightColor.R * mult),
								(int)(highlightColor.G * mult),
								(int)(highlightColor.B * mult));

							depthColors[colorIndex + ImageFrameCommonExtensions.RedIndex] = color.R;
							depthColors[colorIndex + ImageFrameCommonExtensions.GreenIndex] = color.G;
							depthColors[colorIndex + ImageFrameCommonExtensions.BlueIndex] = color.B;
						}
					}

				}

				return depthColors.ToBitmap(width, height);
		}

		// securitycritical covers this
		[SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		//[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
		[SecurityCritical]
		public static Bitmap ToBitmap(this DepthImageFrame image)
		{
			short[] rawDepth = new short[image.PixelDataLength];
			image.CopyPixelDataTo(rawDepth);

			return ImageFrameCommonExtensions.ConvertDepthFrameToBitmap(image).ToBitmap(image.Width, image.Height);
			//return ImageFrameCommonExtensions.ConvertDepthFrameDataToBitmapData(image.Image.Bits, image.Image.Width, image.Image.Height).ToBitmap(image.Image.Width, image.Image.Height);
			
		}

		[SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		//[EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
		[SecurityCritical]
		public static Bitmap ToBitmap(this ColorImageFrame image)
		{
			byte[] colorData = new byte[image.PixelDataLength];

			image.CopyPixelDataTo(colorData);

			return colorData.ToBitmap(image.Width, image.Height); 

		}


	}
}
