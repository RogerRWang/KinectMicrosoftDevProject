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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FaceTrackingBasics
{
    /// <summary>
    /// Interaction logic for ThoughtBubble.xaml
    /// </summary>
    public partial class ThoughtBubble : UserControl
    {
        public ThoughtBubble()
        {
            InitializeComponent();
        }

        public void SetThoughtBubble(string imagePath)
        {
            Uri path = new Uri(@"/Images/" + imagePath,UriKind.Relative);
            BitmapImage img = new BitmapImage(path);           
            _thoughtImage.Source = img; 
        }
    }
}
