using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FaceTrackingBasics
{
    public class FaceReading
    {
        public string Name { get; set; }
        public FaceEmotion ReadingType { get; set; }
        public Single Current { get; set; }
        public Single Average { get; set; }
        public Single Min { get; set; }
        public Single Max { get; set; }
        public float[] AllValues { get; set; }
        const int _maxSampleForAverage = 90; 

        public FaceReading()
        {
            AllValues = new float[_maxSampleForAverage];
        }

        public override string ToString()
        {
            return string.Format("{0} \t {1}", Name, Current.ToString("00.##"));
            //return string.Format("{0} \t {1}    \t {2}    \t {3}    \t {4}", Name, Current.ToString("0.##"), Average.ToString("0.##"), Min.ToString("0.##"), Max.ToString("0.##"));
        }
    }
}
