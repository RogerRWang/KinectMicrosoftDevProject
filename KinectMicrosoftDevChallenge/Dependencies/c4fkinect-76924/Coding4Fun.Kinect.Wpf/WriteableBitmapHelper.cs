using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace Coding4Fun.Kinect.Wpf
{
    public static class WriteableBitmapHelper
    {
       static int DpiX = 96;
       static int DpiY = 96;

       public static WriteableBitmap CreateWriteableBitmap(ColorImageStream colorStream, PixelFormat pixelFormat)
       {
           return CreateWriteableBitmap(colorStream, pixelFormat, null); 
       }

       public static WriteableBitmap CreateWriteableBitmap(ColorImageStream colorStream, PixelFormat pixelFormat, BitmapPalette palette)
       {
           return new WriteableBitmap(colorStream.FrameWidth, colorStream.FrameHeight, DpiX, DpiY, pixelFormat, palette);
       }

        public static WriteableBitmap CreateWriteableBitmap(ColorImageStream colorStream)
        {
            if (colorStream.Format == ColorImageFormat.InfraredResolution640x480Fps30)
            {
                return CreateWriteableBitmap(colorStream, PixelFormats.Gray16, null);
            }
            else
            {
                return CreateWriteableBitmap(colorStream, PixelFormats.Bgr32, null);
            }
             
        }


        public static void WritePixelsForColorImageFrame(ColorImageFrame frame, WriteableBitmap bitmap)
        {
            if (frame == null)
            {
                //lost frame
                return;
            }

            if (bitmap == null)
            {
                throw new ArgumentNullException("bitmap", "WriteableBitmap cannot be null, create a new WriteableBitmap() before calling this method");
            }

            byte[] colorPixels = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(colorPixels);
            Int32Rect imageSize = new Int32Rect(0,0,frame.Width,frame.Height);
            int stride = frame.Width * frame.BytesPerPixel; 

            bitmap.WritePixels(imageSize, colorPixels, stride, 0);
        }

    }
}
