using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FaceTrackingBasics
{
    /// <summary>
    /// Interaction logic for Reposition_Window.xaml
    /// </summary>
    public partial class Reposition_Window : Window
    {
        public Reposition_Window()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double offset = 30;
            Button b = (Button)sender;
            var right  = Canvas.GetLeft(b) + b.ActualWidth + offset;
            var top = Canvas.GetTop(b) - (_bubble.ActualHeight /2) - b.ActualHeight;
            Point p = new Point(right, top);

            MoveToCameraPosition(_bubble, p); 

        }

        private void MoveToCameraPosition(FrameworkElement element, Point point)
        {
           
            //Divide by 2 for width and height so point is right in the middle 
            // instead of in top/left corner
            Canvas.SetLeft(element, point.X );
            Canvas.SetTop(element, point.Y);
        }

        private void MoveToCameraPosition(FrameworkElement element, ColorImagePoint point)
        {
            //Divide by 2 for width and height so point is right in the middle 
            // instead of in top/left corner
            Canvas.SetLeft(element, point.X - element.Width / 2);
            Canvas.SetTop(element, point.Y - element.Height / 2);
        }


    }
}
