using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Cloud.VideoIntelligence.V1;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class testpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "D:\\KYZ\\KYZApp\\Content\\Security\\HotSpexAPI.json");
        try
        {
            //var credential = GoogleCredential.FromFile("D:\\KYZ\\KYZApp\\Content\\Security\\HotSpexAPI.json");
            var credential = GoogleCredential.GetApplicationDefault();
            
            var client = VideoIntelligenceServiceClient.Create();
            var request = new AnnotateVideoRequest()
            {
                InputUri = @"gs://cloud-samples-data/video/cat.mp4",
                Features = { Feature.LabelDetection }
            };
            var op = client.AnnotateVideo(request).PollUntilCompleted();
            foreach (var result in op.Result.AnnotationResults)
            {
                foreach (var annotation in result.SegmentLabelAnnotations)
                {
                    string desc = annotation.Entity.Description;
                    foreach (var entity in annotation.CategoryEntities)
                    {
                        string vidfeolabelDesc = entity.Description;
                    }
                    foreach (var segment in annotation.Segments)
                    {
                        Console.Write("Segment location: ");
                        Console.Write(segment.Segment.StartTimeOffset);
                        Console.Write(":");
                        Console.WriteLine(segment.Segment.EndTimeOffset);
                        System.Console.WriteLine(segment.Confidence);
                    }
                }
            }
        }catch(Exception ex)
        {

            string zz = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
        }
    }

  /*  public static VideoIntelligenceService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
    {

        // check the file exists
        if (!File.Exists(keyFilePath))
        {
            Console.WriteLine("An Error occurred - Key file does not exist");
            return null;
        }

        //string[] scopes = new string[] { YouTubeService.Scope.YoutubeForceSsl };


        try
        {
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    //Scopes = scopes
                }.FromCertificate(certificate));

            VideoIntelligenceServiceSettings.
            // Create the service.
            VideoIntelligenceServiceClient();
            VideoIntelligenceService service = new VideoIntelligenceService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "CAP Survey App",
            });
            return service;
        }
        catch (Exception ex)
        {
            //ErrHandler.WriteLog(ex, "Error In KYZAppDB.GoogleCloud in UploadFile Method in GCSAuthentication.cs--dxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxAuthentication failed\n p12 path=" + keyFilePath);
            //ErrHandler.SendLoggerEmail(ex, "Error In KYZAppDB.GoogleCloud in UploadFile Method in GCSAuthentication.cs xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx-Authentication failed\n p12 path=" + keyFilePath);
            return null;

        }
    }*/
}