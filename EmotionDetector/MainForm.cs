using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmotionDetector.Models;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//the WinForm wrappers

namespace EmotionDetector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Happiness",
                    Values = new ChartValues<double> { 125 },
                    PushOut = 15,
                    DataLabels = false,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Sadness",
                    Values = new ChartValues<double> {125 },
                    DataLabels = false,
                    LabelPoint = labelPoint
                },

                new PieSeries
                {
                    Title = "Anger",
                    Values = new ChartValues<double> { 125 },
                    DataLabels = false,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Contempt",
                    Values = new ChartValues<double> { 125 },
                    DataLabels = false,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Disgust",
                    Values = new ChartValues<double> {125 },
                    DataLabels = false,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Fear",
                    Values = new ChartValues<double> { 125 },
                    DataLabels = false,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Surprise",
                    Values = new ChartValues<double> { 125 },
                    DataLabels = false,
                    LabelPoint = labelPoint
                },

                new PieSeries
                {
                    Title = "Neutral",
                    Values = new ChartValues<double> { 125 },
                    DataLabels = false,
                    LabelPoint = labelPoint
                },
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;

        }


        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        private static bool IsAnimating(PictureBox box)
        {
            var fi = box.GetType().GetField("currentlyAnimating",
                BindingFlags.NonPublic | BindingFlags.Instance);
            return (bool)fi.GetValue(box);
        }
        private static void Animate(PictureBox box, bool enable)
        {
            var anim = box.GetType().GetMethod("Animate",
                BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(bool) }, null);
            anim.Invoke(box, new object[] { enable });
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog1.FileName);
                pctMain.ImageLocation = openFileDialog1.FileName;

            }
        }

        private async void btnTry_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new HttpClient();

                // Request headers - replace this example key with your valid key.
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "8c7684b6f4e448aab05e87145b498b96"); // 

                // NOTE: You must use the same region in your REST call as you used to obtain your subscription keys.
                //   For example, if you obtained your subscription keys from westcentralus, replace "westus" in the 
                //   URI below with "westcentralus".
                string uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
                HttpResponseMessage response;
                string responseContent;

                // Request body. Try this sample with a locally stored JPEG image.
                if (string.IsNullOrEmpty(pctMain.ImageLocation))
                {
                    MessageBox.Show("Invalid Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                byte[] byteData = GetImageAsByteArray(pctMain.ImageLocation);

                pctFeedback.Image = Properties.Resources.ic_too_sad;
                Animate(pctLoading, !IsAnimating(pctLoading));

                using (var content = new ByteArrayContent(byteData))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json" and "multipart/form-data".
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response = await client.PostAsync(uri, content);
                    responseContent = response.Content.ReadAsStringAsync().Result;
                }

                Animate(pctLoading, !IsAnimating(pctLoading));

                var faceEmotions = JsonConvert.DeserializeObject<List<FaceEmotion>>(responseContent);
                var score = faceEmotions[0].scores;


                Func<ChartPoint, string> labelPoint = chartPoint =>
                    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

                pieChart1.Series = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title = "Happiness",
                            Values = new ChartValues<double> { score.happiness },
                            PushOut = 15,
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                        new PieSeries
                        {
                            Title = "Sadness",
                            Values = new ChartValues<double> { score.sadness },
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },

                        new PieSeries
                        {
                            Title = "Anger",
                            Values = new ChartValues<double> { score.anger },
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                        new PieSeries
                        {
                            Title = "Contempt",
                            Values = new ChartValues<double> { score.contempt },
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                        new PieSeries
                        {
                            Title = "Disgust",
                            Values = new ChartValues<double> { score.disgust },
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                        new PieSeries
                        {
                            Title = "Fear",
                            Values = new ChartValues<double> { score.fear },
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                        new PieSeries
                        {
                            Title = "Surprise",
                            Values = new ChartValues<double> { score.surprise },
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },

                        new PieSeries
                        {
                            Title = "Neutral",
                            Values = new ChartValues<double> { score.neutral },
                            DataLabels = false,
                            LabelPoint = labelPoint
                        },
                    };

                pieChart1.LegendLocation = LegendLocation.Bottom;

                var happy = pieChart1.Series.Where(s => (double)s.Values[0] > score.happiness);
                var sad = pieChart1.Series.Where(s => (double)s.Values[0] > score.sadness);
                var anger = pieChart1.Series.Where(s => (double)s.Values[0] > score.anger);
                var contempt = pieChart1.Series.Where(s => (double)s.Values[0] > score.contempt);
                var disgust = pieChart1.Series.Where(s => (double)s.Values[0] > score.disgust);
                var fear = pieChart1.Series.Where(s => (double)s.Values[0] > score.fear);
                var surprise = pieChart1.Series.Where(s => (double)s.Values[0] > score.surprise);
                var neutral = pieChart1.Series.Where(s => (double)s.Values[0] > score.neutral);
                
                if (!happy.Any())//check if happiness is the largest
                {
                    pctFeedback.Image = Properties.Resources.ic_happy;
                }
                if (!sad.Any())
                {
                    pctFeedback.Image = Properties.Resources.ic_sadness;
                }
                if (!anger.Any())
                {
                    pctFeedback.Image = Properties.Resources.ic_anger;
                }
                if (!contempt.Any())
                {
                    pctFeedback.Image = Properties.Resources.ic_contempt;
                }
                if (!disgust.Any())
                {
                    pctFeedback.Image = Properties.Resources.ic_disgust;
                }

                if (!fear.Any())
                {
                    pctFeedback.Image = Properties.Resources.ic_fear;
                }

                if (!surprise.Any())
                {
                    pctFeedback.Image = Properties.Resources.ic_surprise;
                }

                if (!neutral.Any())
                {
                    pctFeedback.Image = Properties.Resources.ic_natural;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void tmrStopAnimation_Tick(object sender, EventArgs e)
        {
            tmrStopAnimation.Enabled = false;
            Animate(pctLoading, !IsAnimating(pctLoading));
        }
    }
}
