﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionDetector.Models
{
//    [
//  {
//    "faceRectangle": {
//      "left": 68,
//      "top": 97,
//      "width": 64,
//      "height": 97
//    },
//    "scores": {
//      "anger": 0.00300731952,
//      "contempt": 5.14648448E-08,
//      "disgust": 9.180124E-06,
//      "fear": 0.0001912825,
//      "happiness": 0.9875571,
//      "neutral": 0.0009861537,
//      "sadness": 1.889955E-05,
//      "surprise": 0.008229999
//    }
//  }
//]
    class Face
    {
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}