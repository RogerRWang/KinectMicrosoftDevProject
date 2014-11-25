// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Windows;
using System.Windows.Media;

using Microsoft.Research.Kinect.Nui;

namespace Coding4Fun.Kinect.Wpf.TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeRuntime();
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

            var useSkeleton = TrackSkeleton.IsChecked != null && TrackSkeleton.IsChecked.Value;
            var useDepth = TrackDepth.IsChecked != null && TrackDepth.IsChecked.Value;
			var useDepthAndPlayerIndex = TrackDepthAndPlayerIndex.IsChecked != null && TrackDepthAndPlayerIndex.IsChecked.Value;
			
            var useColor = TrackColor.IsChecked != null && TrackColor.IsChecked.Value;

            if (useSkeleton)
                flags |= RuntimeOptions.UseSkeletalTracking;

			if(useDepthAndPlayerIndex)
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
            if (useColor)
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
            ColorImage.Source = e.ImageFrame.ToBitmapSource();
			
			if (_saveColorFrame)
			{
				_saveColorFrame = false;
				e.ImageFrame.ToBitmapSource().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_color.jpg", ImageFormat.Jpeg);

			}
        }

        void RuntimeDepthFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            DepthImage.Source = e.ImageFrame.ToBitmapSource();
			if (_saveDepthFrame)
			{
				_saveDepthFrame = false;
				e.ImageFrame.ToBitmapSource().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_depth.jpg", ImageFormat.Jpeg);
			}

        	var imageWidth = e.ImageFrame.Image.Width;
            var imageHeight = e.ImageFrame.Image.Height;

            var depthArray = e.ImageFrame.ToDepthArray();

            //var averageleftSidePoint = depthArray.GetMidpoint(imageWidth, imageHeight, 0, 0, imageWidth / 2, imageHeight, _minDistance);
            //var averageRightSidePoint = depthArray.GetMidpoint(imageWidth, imageHeight, imageWidth / 2, 0, imageWidth - 1, imageHeight, _minDistance);

            MidPointDistanceText.Text = e.ImageFrame.ToDepthArray2D()[160][120].ToString();
			MidPointDistanceViaGetDistanceText.Text = e.ImageFrame.GetDistance(160, 120).ToString();
            DepthImageWithMinDistance.Source = depthArray.ToBitmapSource(imageWidth, imageHeight, _minDistance, Color.FromArgb(255, 255, 0, 0));
        }

        void RuntimeSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UninitializeRuntime();
        }

        private void DistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _minDistance = (int)e.NewValue;
			DistanceText.Text = _minDistance.ToString();
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

        private void ReinitRuntime_Click(object sender, RoutedEventArgs e)
        {
            InitializeRuntime();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
			_saveColorFrame =
				_saveDepthFrame = true;
        }
    }
}
