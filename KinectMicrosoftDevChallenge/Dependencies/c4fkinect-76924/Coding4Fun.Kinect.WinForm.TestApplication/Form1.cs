// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.Kinect;

namespace Coding4Fun.Kinect.WinForm.TestApplication
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			SetupKinect();
			DistanceSlider_Scroll(null, null);
		}

		int _minDistance;
		KinectSensor _sensor;

		bool _isInit;
		bool _saveColorFrame;
		bool _saveDepthFrame;

		private void SetupKinect()
		{
			if (_isInit)
				StopKinect();

			if (KinectSensor.KinectSensors.Count > 0)
			{
				//pull the first Kinect
				_sensor = KinectSensor.KinectSensors[0];
			}
			if (_sensor.Status != KinectStatus.Connected || KinectSensor.KinectSensors.Count == 0)
			{
				MessageBox.Show("No Kinect connected"); 
				return; 
			}

			_sensor.SkeletonStream.Enable();
			_sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
			_sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30); 

			_sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(_sensor_AllFramesReady);

			_sensor.Start(); 
			_isInit = true;
		}

		void _sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
		{
			RuntimeColorFrameReady(e);
			RuntimeDepthFrameReady(e); 
			
		}

		void RuntimeColorFrameReady(AllFramesReadyEventArgs e)
		{

			using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
			{
				if (colorFrame == null)
				{
					return; 
				}

				ColorImage.Image = colorFrame.ToBitmap();

				if (_saveColorFrame)
				{
					_saveColorFrame = false;
					colorFrame.ToBitmap().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_color.jpg", ImageFormat.Jpeg);
				}
			}           
		}

		void RuntimeDepthFrameReady(AllFramesReadyEventArgs e)
		{
			using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
			{
				if (depthFrame == null)
				{
					return; 
				}

                //turn raw data into array of distances
				var depthArray = depthFrame.ToDepthArray();

                //get image
				DepthImage.Image = depthFrame.ToBitmap();

                //get midpoint
				MidPointDistanceViaGetDistanceText.Text = depthFrame.GetDistance(depthFrame.Width/2, depthFrame.Height/2).ToString();

				//image
				DepthImageWithMinDistance.Image = depthArray.ToBitmap(depthFrame.Width, depthFrame.Height, _minDistance, Color.FromArgb(255, 255, 0, 0));

				if (_saveDepthFrame)
				{
					_saveDepthFrame = false;
					depthFrame.ToBitmap().Save(DateTime.Now.ToString("yyyyMMddHHmmss") + "_depth.jpg", ImageFormat.Jpeg);
				}

			}

		}


		public void StopKinect()
		{
			if (_sensor != null)
			{
				_sensor.Stop(); 
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
			SetupKinect();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			StopKinect();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			_saveColorFrame = true; 
			_saveDepthFrame = true;
		}
	}
}
