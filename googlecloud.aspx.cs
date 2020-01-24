using Google.Cloud.Speech.V1;
using Google.Cloud.VideoIntelligence.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class googlecloud : System.Web.UI.Page
{
    // The name of the local audio file to transcribe
    public static string DEMO_FILE = "gs://hsx-cmt/Tide_Super_Bowl_LII_2018_Commercial_It_s_Yet_Another_Tide_Ad_Again.mp4";
    protected void Page_Load(object sender, EventArgs e)
    {
        //AnalyzeLabels("gs://hsx-cmt/Tide_Super_Bowl_LII_2018_Commercial_It_s_Yet_Another_Tide_Ad_Again.mp4");
        speechToText();
    }
    public static void speechToText()
    {
        var speech = SpeechClient.Create();
        var response = speech.Recognize(new RecognitionConfig()
        {
            Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
            SampleRateHertz = 16000,
            LanguageCode = "en",
        }, RecognitionAudio.FromFile(DEMO_FILE));
        foreach (var result in response.Results)
        {
            foreach (var alternative in result.Alternatives)
            {
                Console.WriteLine(alternative.Transcript);
            }
        }
    }



    public static object AnalyzeLabels(string path)
    {
        var client = VideoIntelligenceServiceClient.Create();
        var request = new AnnotateVideoRequest()
        {
            InputContent = Google.Protobuf.ByteString.CopyFrom(File.ReadAllBytes(path)),
            Features = { Feature.LabelDetection }
        };
        var op = client.AnnotateVideo(request).PollUntilCompleted();
        foreach (var result in op.Result.AnnotationResults)
        {
            //PrintLabels("Video", result.SegmentLabelAnnotations);
            //PrintLabels("Shot", result.ShotLabelAnnotations);
            //PrintLabels("Frame", result.FrameLabelAnnotations);
        }
        return 0;
    }
}