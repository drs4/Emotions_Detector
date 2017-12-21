using System;
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
    class Score
    {
        public double anger { get; set; }
        public double contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }

        public double sum { get { return anger+contempt+disgust+fear+happiness+neutral+sadness+surprise; } }

        public double other { get { return 1 - sum; } }
    }
}
