// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.Research.Kinect.Nui;

namespace Coding4Fun.Kinect.WinForm.TestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            InitializeRuntime();
			DistanceSlider_Scroll(null, null);
        }

        int _minDistance;
        Runtime _runtime;

		bool _isInit;
		bool _saveColorFrame;
		bool _saveDepthFrame;

        private void InitializeRuntime()
        {
            if (_isInit)
                UninitializeRuntime();

			_runtime = Runtime.Kinects[0];

            RuntimeOptions flags = 0;

			var useSkeleton = TrackSkeleton.Checked;
			var useDepth = TrackDepth.Checked;
			var useDepthAndPlayerIndex = TrackDepthAndPlayerIndex.Checked;

			var useColor = TrackColor.Checked;

			if (useSkeleton)
				flags |= RuntimeOptions.UseSkeletalTracking;

			if (useDepthAndPlayerIndex)
				flags |= RuntimeOptions.UseDepthAndPlayerIndex;

			if (useDepth)
				flags |= RuntimeOptions.UseDepth;

			if (useColor)
				flags |= RuntimeOptions.UseColor;

			_runtime.Initialize(flags);

			if (useDepthAndPlayerIndex || useDepth)
			{
				var imageType = (useDepthAndPlayerIndex) ? ImageType.DepthAndPlayerIndex : ImageType.Depth;
				_runtime.DepthStream.Open(ImageStreamType.Depth, 2, ImageResolution.Resolution320x240, imageType);
			}


            // now open streams
            if (TrackColor.Checked)
            {
                _runtime.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color);
            }

            _runtime.VideoFrameReady += RuntimeColorFrameReady;
            _runtime.DepthFrameReady += RuntimeDepthFrameReady;
            _runtime.SkeletonFrameReady += RuntimeSkeletonFrameReady;

            _isInit = true;
        }

        void RuntimeColorFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            ColorImage.Image = e.ImageFrame.ToBitmap();

			if (_saveColorFrame)
			{
				_saveColorFrame = false;
				e.ImageFrame.ToBitmap().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_color.jpg", ImageFormat.Jpeg);

			}
        }

        void RuntimeDepthFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            DepthImage.Image = e.ImageFrame.ToBitmap();
			if (_saveDepthFrame)
			{
				_saveDepthFrame = false;
				e.ImageFrame.ToBitmap().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_depth.jpg", ImageFormat.Jpeg);
			}
            var imageWidth = e.ImageFrame.Image.Width;
            var imageHeight = e.ImageFrame.Image.Height;

            var depthArray = e.ImageFrame.ToDepthArray();

            //var averageleftSidePoint = depthArray.GetMidpoint(imageWidth, imageHeight, 0, 0, imageWidth / 2, imageHeight, _minDistance);
            //var averageRightSidePoint = depthArray.GetMidpoint(imageWidth, imageHeight, imageWidth / 2, 0, imageWidth - 1, imageHeight, _minDistance);

            //Debug.WriteLine(averageleftSidePoint);
            //Debug.WriteLine(averageRightSidePoint);
			MidPointDistanceText.Text = e.ImageFrame.ToDepthArray2D()[160][120].ToString();
			MidPointDistanceViaGetDistanceText.Text = e.ImageFrame.GetDistance(160, 120).ToString();

            DepthImageWithMinDistance.Image = depthArray.ToBitmap(imageWidth, imageHeight, _minDistance, Color.FromArgb(255, 255, 0, 0));
        }

        void RuntimeSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
        }

        public void UninitializeRuntime()
        {
			if (_runtime != null)
			{
				_runtime.VideoFrameReady -= RuntimeColorFrameReady;
				_runtime.DepthFrameReady -= RuntimeDepthFrameReady;
				_runtime.SkeletonFrameReady -= RuntimeSkeletonFrameReady;

				_runtime.Uninitialize();
			}

        	_isInit = false;
        }

        private void DistanceSlider_Scroll(object sender, EventArgs e)
        {
            _minDistance = DistanceSlider.Value;
			DistanceText.Text = _minDistance.ToString();
        }

        private void ReinitRuntime_Click(object sender, EventArgs e)
        {
            InitializeRuntime();
        }

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			UninitializeRuntime();
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
			_saveColorFrame =
				_saveDepthFrame = true;
        }
    }
}
