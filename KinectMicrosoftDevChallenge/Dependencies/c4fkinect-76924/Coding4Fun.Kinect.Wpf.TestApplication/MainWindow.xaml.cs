// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Windows;
using System.Windows.Media;

using Microsoft.Kinect;

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
		}

		int _minDistance;	
		

		bool _saveColorFrame;
		bool _saveDepthFrame;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kinectSensorChooser.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kinectSensorChooser_KinectSensorChanged);
        }


		void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
		{
			sensor_ColorFrameReady(e);
			sensor_DepthFrameReady(e);
		}


		void sensor_ColorFrameReady(AllFramesReadyEventArgs e)
		{
			using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
			{
				if (colorFrame == null)
				{
					return; 
				}

				//set image
				ColorImage.Source = colorFrame.ToBitmapSource(); 

				if (_saveColorFrame)
				{
					//save image

					colorFrame.ToBitmapSource().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_color.jpg", ImageFormat.Jpeg);
				}
			}            
		}

		void sensor_DepthFrameReady(AllFramesReadyEventArgs e)
		{
			using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
			{
				if (depthFrame == null)
				{
					return; 
				}

				//turn raw data into an array of distances; 
				var depthArray = depthFrame.ToDepthArray();

				MidPointDistanceViaGetDistanceText.Text = depthFrame.GetDistance(depthFrame.Width/2, depthFrame.Height/2).ToString();

				//image
				DepthImageWithMinDistance.Source = depthArray.ToBitmapSource(depthFrame.Width, depthFrame.Height,
																			_minDistance, Colors.Red);

				//image
				DepthImage.Source = depthFrame.ToBitmapSource();

				if (_saveDepthFrame)
				{
					_saveDepthFrame = false;
					depthFrame.ToBitmapSource().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_depth.jpg", ImageFormat.Jpeg);
				}

			}
		}

		
		private void DistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_minDistance = (int)e.NewValue;
			DistanceText.Text = _minDistance.ToString();
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			_saveColorFrame = true; 
			_saveDepthFrame = true;
		}


        void kinectSensorChooser_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            KinectSensor old = (KinectSensor)e.OldValue;

            StopKinect(old);

            KinectSensor sensor = (KinectSensor)e.NewValue;

            if (sensor == null)
            {
                return;
            }

            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            sensor.SkeletonStream.Enable();

            sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(sensor_AllFramesReady);


            try
            {
                sensor.Start();
            }
            catch (System.IO.IOException)
            {
                //another app is using Kinect
                kinectSensorChooser.AppConflictOccurred();
            }
        }

        private void StopKinect(KinectSensor sensor)
        {
            if (sensor != null)
            {
                if (sensor.IsRunning)
                {
                    sensor.Stop();
                    sensor.AudioSource.Stop();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            StopKinect(kinectSensorChooser.Kinect); 
        }


	}
}
